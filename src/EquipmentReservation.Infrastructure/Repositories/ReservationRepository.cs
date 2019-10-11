using EquipmentReservation.Domain.Accounts;
using EquipmentReservation.Domain.Equipments;
using EquipmentReservation.Domain.Reservations;
using EquipmentReservation.Infrastructure.Database;
using EquipmentReservation.Infrastructure.Database.Tables;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EquipmentReservation.Infrastructure.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly MyDbContext _dbContext;

        public ReservationRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public Reservation Find(ReservationId reservationId, ReservationStatus? reservationStatus = null)
        {
            RESERVATIONS reservation = null;

            if (reservationStatus == null)
            {
                reservation = _dbContext.Reservations.Include(_ => _.reservations_status).
                    SingleOrDefault(_ => _.id == reservationId.Value);
            }
            else
            {
                reservation = _dbContext.Reservations.Include(_ => _.reservations_status).
                    Where(_ => _.reservations_status.status == (int)reservationStatus.Value).
                    SingleOrDefault(_ => _.id == reservationId.Value);
            }

            if (reservation == null) return null;

            return Create(reservation);

        }

        public IEnumerable<Reservation> FindByEquipmentId(EquipmentId equipmentId, ReservationStatus? reservationStatus = null)
        {
            if (reservationStatus == null)
            {
                return _dbContext.Reservations.Include(_ => _.reservations_status).
                    Where(_ => _.equipments_id == equipmentId.Value).
                    Select(_ => Create(_));
            }
            else
            {
                return _dbContext.Reservations.Include(_ => _.reservations_status).
                    Where(_ => _.reservations_status.status == (int)reservationStatus.Value).
                    Where(_ => _.equipments_id == equipmentId.Value).
                    Select(_ => Create(_));
            }
        }

        public void Save(Reservation entity)
        {
            var reservation = _dbContext.Reservations.Find(entity.Id.Value);
            var reservationExists = reservation != null;
            if (!reservationExists)
            {
                reservation = new RESERVATIONS();
            }

            reservation.id = entity.Id.Value;
            reservation.accounts_id = entity.AccountId.Value;
            reservation.equipments_id = entity.EquipmentId.Value;
            reservation.start_date_time = entity.ReservationDateTime.Start;
            reservation.end_date_time = entity.ReservationDateTime.End;
            reservation.purpose_of_use = entity.PurposeOfUse;

            if (!reservationExists)
            {
                _dbContext.Reservations.Add(reservation);
            }
            else
            {
                _dbContext.Reservations.Update(reservation);
            }


            var reservationStatus = _dbContext.ReservationsStatus.Find(reservation.id);
            var reservationStatusExists = reservationStatus != null;
            if (!reservationStatusExists)
            {
                reservationStatus = new RESERVATIONS_STATUS();
            }

            reservationStatus.reservations_id = reservation.id;
            if (entity.ReservationStatus == ReservationStatus.Reserved)
            {
                reservationStatus.status = 0;
            }
            else if (entity.ReservationStatus == ReservationStatus.Canceled)
            {
                reservationStatus.status = 1;
            }

            if (!reservationStatusExists)
            {
                _dbContext.ReservationsStatus.Add(reservationStatus);
            }
            else
            {
                _dbContext.ReservationsStatus.Update(reservationStatus);
            }

            _dbContext.SaveChanges();
        }

        public void Lock()
        {
            _dbContext.QueryObjects<RESERVATIONS>("select * from reservations for update;");
        }

        private Reservation Create(RESERVATIONS reservation)
        {
            return new Reservation(
                new ReservationId(reservation.id),
                new AccountId(reservation.accounts_id),
                new EquipmentId(reservation.equipments_id),
                new ReservationDateTime(reservation.start_date_time, reservation.end_date_time),
                reservation.purpose_of_use,
                (ReservationStatus)reservation.reservations_status.status);
        }
    }
}

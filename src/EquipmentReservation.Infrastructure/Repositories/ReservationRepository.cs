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
            IQueryable<RESERVATIONS> reservations = _dbContext.Reservations.Include(_ => _.reservations_status);

            if (reservationStatus != null)
            {
                reservations = reservations.Where(_ => _.reservations_status.status == (int)reservationStatus.Value);
            }

            var reservation = reservations.SingleOrDefault(_ => _.id == reservationId.Value);

            return Create(reservation);
        }

        public IEnumerable<Reservation> FindByEquipmentId(EquipmentId equipmentId, ReservationStatus? reservationStatus = null)
        {
            var reservations = _dbContext.Reservations.Include(_ => _.reservations_status).
                Where(_ => _.equipments_id == equipmentId.Value);

            if (reservationStatus != null)
            {
                reservations = reservations.Where(_ => _.reservations_status.status == (int)reservationStatus.Value);
            }

            return reservations.Select(_ => Create(_)).ToArray();
        }

        public void Save(Reservation entity)
        {
            var reservation = _dbContext.Reservations.Find(entity.Id.Value);
            if (reservation == null)
            {
                reservation = new RESERVATIONS();
                _dbContext.Reservations.Add(reservation);
            }

            reservation.id = entity.Id.Value;
            reservation.accounts_id = entity.AccountId.Value;
            reservation.equipments_id = entity.EquipmentId.Value;
            reservation.start_date_time = entity.ReservationDateTime.Start;
            reservation.end_date_time = entity.ReservationDateTime.End;
            reservation.purpose_of_use = entity.PurposeOfUse.Value;


            var reservationStatus = _dbContext.ReservationsStatus.Find(reservation.id);
            if (reservationStatus == null)
            {
                reservationStatus = new RESERVATIONS_STATUS();
                _dbContext.ReservationsStatus.Add(reservationStatus);
            }

            reservationStatus.reservations_id = reservation.id;
            reservationStatus.status = (int)entity.ReservationStatus;

            _dbContext.SaveChanges();
        }

        public void Lock()
        {
            _dbContext.QueryObjects<RESERVATIONS>("select * from reservations for update;");
        }

        private Reservation Create(RESERVATIONS reservation)
        {
            if (reservation == null)
                return null;

            return new Reservation(
                new ReservationId(reservation.id),
                new AccountId(reservation.accounts_id),
                new EquipmentId(reservation.equipments_id),
                new ReservationDateTime(reservation.start_date_time, reservation.end_date_time),
                new PurposeOfUse(reservation.purpose_of_use),
                (ReservationStatus)reservation.reservations_status.status);
        }
    }
}

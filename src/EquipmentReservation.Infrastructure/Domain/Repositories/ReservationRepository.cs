using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using EquipmentReservation.Domain.Accounts;
using EquipmentReservation.Domain.Equipments;
using EquipmentReservation.Domain.Reservations;
using EquipmentReservation.Infrastructure.Database;
using EquipmentReservation.Infrastructure.Database.Tables;

namespace EquipmentReservation.Infrastructure.Domain.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly MyDbContext _dbContext;

        public ReservationRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public Reservation Find(ReservationId reservationId)
        {
            var reservation = _dbContext.Reservations.Find(reservationId.Value);
            if (reservation == null) return null;

            return Create(reservation);
        }

        public IEnumerable<Reservation> FindByEquipmentId(EquipmentId equipmentId)
        {
            return _dbContext.Reservations.Where(_ => equipmentId.Equals(new EquipmentId(_.equipments_id))).Select(_ => Create(_)).ToArray();
        }

        public void Save(Reservation entity)
        {
            var reservation = _dbContext.Reservations.Find(entity.Id.Value);

            if (entity.Canceled)
            {
                _dbContext.Reservations.Remove(reservation);
                _dbContext.SaveChanges();
                return;
            }

            var exists = reservation != null;
            if (reservation == null)
            {
                reservation = new RESERVATIONS();
            }

            reservation.id = entity.Id.Value;
            reservation.accounts_id = entity.AccountId.Value;
            reservation.equipments_id = entity.EquipmentId.Value;
            reservation.start_date_time = entity.ReservationDateTime.Start;
            reservation.end_date_time = entity.ReservationDateTime.End;
            reservation.purpose_of_use = entity.PurposeOfUse;

            if (!exists)
            {
                _dbContext.Reservations.Add(reservation);
            }
            else
            {
                _dbContext.Reservations.Update(reservation);
            }

            _dbContext.SaveChanges();
        }

        public void Lock()
        {
            new QueryableRepository(_dbContext).QueryObjects<RESERVATIONS>("select * from reservations for update;");
        }

        private Reservation Create(RESERVATIONS reservation)
        {
            return new Reservation(
                new ReservationId(reservation.id),
                new AccountId(reservation.accounts_id),
                new EquipmentId(reservation.equipments_id),
                new ReservationDateTime(reservation.start_date_time, reservation.end_date_time),
                reservation.purpose_of_use);
        }
    }
}

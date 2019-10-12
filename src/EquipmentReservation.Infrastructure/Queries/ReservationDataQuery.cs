using EquipmentReservation.Application.Reservations.Data;
using EquipmentReservation.Application.Reservations.Queries;
using EquipmentReservation.Domain.Reservations;
using EquipmentReservation.Infrastructure.Database;
using EquipmentReservation.Infrastructure.Database.Tables;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EquipmentReservation.Infrastructure.Queries
{
    public class ReservationDataQuery : IReservationDataQuery
    {
        private readonly MyDbContext _dbContext;

        public ReservationDataQuery(MyDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public ReservationData FindReservationData(ReservationId reservationId)
        {
            var reservation = _dbContext.Reservations.Find(reservationId.Value);

            return CreateReservationData(reservation);
        }

        public IEnumerable<ReservationListData> FindAllReservationListData()
        {
            return _dbContext.Reservations.
                Include(_ => _.accounts).
                Include(_ => _.equipments).
                Include(_ => _.reservations_status).
                Where(_ => _.reservations_status.status == (int)ReservationStatus.Reserved).
                Select(_ => CreateReservationListData(_)).ToArray();
        }

        public ReservationListData FindReservationListData(ReservationId reservationId)
        {
            var reservation = _dbContext.Reservations.
                Include(_ => _.accounts).
                Include(_ => _.equipments).
                Where(_ => _.id == reservationId.Value).
                SingleOrDefault();

            return CreateReservationListData(reservation);
        }

        private ReservationData CreateReservationData(RESERVATIONS reservation)
        {
            if (reservation == null)
                return null;

            return new ReservationData()
            {
                Id = reservation.id,
                AccountId = reservation.accounts.id,
                EquipmentId = reservation.equipments_id,
                StartDateTime = reservation.start_date_time,
                EndDateTime = reservation.end_date_time,
                PurposeOfUse = reservation.purpose_of_use,
            };
        }

        private ReservationListData CreateReservationListData(RESERVATIONS reservation)
        {
            if (reservation == null)
                return null;

            return new ReservationListData()
            {
                Id = reservation.id,
                AccountId = reservation.accounts.id,
                EquipmentId = reservation.equipments_id,
                StartDateTime = reservation.start_date_time,
                EndDateTime = reservation.end_date_time,
                PurposeOfUse = reservation.purpose_of_use,
                AccountName = reservation.accounts.account_name,
                EquipmentType = reservation.equipments.equipment_type,
                EquipmentName = reservation.equipments.equipment_name
            };
        }
    }
}

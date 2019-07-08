using EquipmentReservation.Application.Reservations.Data;
using EquipmentReservation.Application.Reservations.Queries;
using EquipmentReservation.Domain.Reservations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EquipmentReservation.Infrastructure.Application.Repositories
{
    public class ReservationDataQuery : IReservationDataQuery
    {
        private string GetQuery(string baseQuery, string whereClause = null)
        {
            return string.Format(baseQuery, whereClause);
        }

        private const string GetReservationDataQuery = @"
                select
                    reservation.RESERVATION_KEY as Id,
                    reservation.ACCOUNT_KEY as AccuntId,
                    reservation.EQUIPMENT_KEY as EquipmentId,
                    reservation.START_DATE_TIME as StartDateTime,
                    reservation.END_DATE_TIME as EndDateTime,
                    reservation.PURPOSE_OF_USE as PurposeOfUse
                from
                    T_RESERVATION reservation
                {0}
                order by
                    reservation.START_DATE_TIME,
                    reservation.RESERVATION_KEY;
                ";

        public IEnumerable<ReservationData> FindAllReservationData()
        {
            var reservationDataList = new List<ReservationData>();
            foreach (var reservation in Domain.Repositories.ReservationRepository._data)
            {
                reservationDataList.Add(new ReservationData()
                {
                    Id = reservation.Id.Value,
                    AccountId = reservation.AccountId.Value,
                    EquipmentId = reservation.EquipmentId.Value,
                    StartDateTime = reservation.ReservationDateTime.Start,
                    EndDateTime = reservation.ReservationDateTime.End,
                    PurposeOfUse = reservation.PurposeOfUse
                });
            }
            return reservationDataList;

            return new QueryableRepository().QueryObjects<ReservationData>(GetQuery(GetReservationDataQuery));
        }

        public ReservationData FindReservationData(ReservationId reservationId)
        {
            return FindAllReservationListData().FirstOrDefault(_ => _.Id == reservationId.Value);

            var whereClause = @"
                where
                    reservation.RESERVATION_KEY = ?";

            return new QueryableRepository().QueryObject<ReservationData>(GetQuery(GetReservationDataQuery, whereClause), reservationId.Value);
        }

        private const string GetReservationListDataQuery = @"
                select
                    reservation.RESERVATION_KEY as Id,
                    reservation.ACCOUNT_KEY as AccuntId,
                    account.NAME as AccountName,
                    reservation.EQUIPMENT_KEY as EquipmentId,
                    equipment.EQUIPMENT_TYPE as EquipmentType,
                    equipment.NAME as EquipmentName,
                    reservation.START_DATE_TIME as StartDateTime,
                    reservation.END_DATE_TIME as EndDateTime,
                    reservation.PURPOSE_OF_USE as PurposeOfUse
                from
                    T_RESERVATION reservation
                    join M_ACCOUNT account on reservation.ACCOUNT_KEY = account.ACCOUNT_KEY,
                    join M_EQUIPMENT equipment on reservation.EQUIPMENT_KEY = equipment.EQUIPMENT_KEY
                {0}
                order by
                    reservation.START_DATE_TIME,
                    reservation.RESERVATION_KEY;
                ";

        public IEnumerable<ReservationListData> FindAllReservationListData()
        {
            var reservationListDataList = new List<ReservationListData>();
            foreach(var reservation in Domain.Repositories.ReservationRepository._data)
            {
                var account = Domain.Repositories.AccountRepository._data.Find(_ => _.Id.Equals(reservation.AccountId));
                var equipment = Domain.Repositories.EquipmentRepository._data.Find(_ => _.Id.Equals(reservation.EquipmentId));
                reservationListDataList.Add(new ReservationListData()
                {
                    Id = reservation.Id.Value,
                    AccountId = reservation.AccountId.Value,
                    AccountName = account.Name,
                    EquipmentId = reservation.EquipmentId.Value,
                    EquipmentType = (int)equipment.EquipmentType,
                    EquipmentName = equipment.Name,
                    StartDateTime = reservation.ReservationDateTime.Start,
                    EndDateTime = reservation.ReservationDateTime.End,
                    PurposeOfUse = reservation.PurposeOfUse
                });
            }
            return reservationListDataList;

            return new QueryableRepository().QueryObjects<ReservationListData>(GetQuery(GetReservationListDataQuery));
        }

        public ReservationListData FindReservationListData(ReservationId reservationId)
        {
            return FindAllReservationListData().FirstOrDefault(_ => _.Id == reservationId.Value);

            var whereClause = @"
                where
                    reservation.RESERVATION_KEY = ?";

            return new QueryableRepository().QueryObject<ReservationListData>(GetQuery(GetReservationListDataQuery, whereClause), reservationId.Value);
        }
    }
}

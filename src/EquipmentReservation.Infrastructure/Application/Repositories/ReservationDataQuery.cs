using EquipmentReservation.Application.Reservations.Data;
using EquipmentReservation.Application.Reservations.Queries;
using EquipmentReservation.Domain.Reservations;
using EquipmentReservation.Infrastructure.Application.Repositories.Commons;
using EquipmentReservation.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace EquipmentReservation.Infrastructure.Application.Repositories
{
    public class ReservationDataQuery : QueryableRepository, IReservationDataQuery
    {
        public ReservationDataQuery(MyDbContext dbContext) : base(dbContext) { }

        private string GetQuery(string baseQuery, string whereClause = null)
        {
            return string.Format(baseQuery, whereClause);
        }

        private const string GetReservationDataQuery = @"
                select
                    id as Id,
                    accounts_id as AccountId,
                    equipments_id as EquipmentId,
                    start_date_time as StartDateTime,
                    end_date_time as EndDateTime,
                    purpose_of_use as PurposeOfUse
                from
                    reservations
                {0}
                order by
                    start_date_time,
                    end_date_time;
                ";

        public IEnumerable<ReservationData> FindAllReservationData()
        {
            return QueryObjects<ReservationData>(GetQuery(GetReservationDataQuery));
        }

        public ReservationData FindReservationData(ReservationId reservationId)
        {
            var whereClause = @"where id = @id";

            var parameter = new { id = reservationId.Value };

            return QueryObject<ReservationData>(GetQuery(GetReservationDataQuery, whereClause), parameter);
        }

        private const string GetReservationListDataQuery = @"
                select
                    reservation.id as Id,
                    reservation.accounts_id as AccountId,
                    reservation.equipments_id as EquipmentId,
                    reservation.start_date_time as StartDateTime,
                    reservation.end_date_time as EndDateTime,
                    reservation.purpose_of_use as PurposeOfUse,
                    account.account_name as AccountName,
                    equipment.equipment_type as EquipmentType,
                    equipment.equipment_name as EquipmentName
                from
                    reservations reservation
                    inner join accounts account on reservation.accounts_id = account.id
                    inner join equipments equipment on reservation.equipments_id = equipment.id
                {0}
                order by
                    reservation.start_date_time,
                    reservation.end_date_time;
                ";

        public IEnumerable<ReservationListData> FindAllReservationListData()
        {
            return QueryObjects<ReservationListData>(GetQuery(GetReservationListDataQuery));
        }

        public ReservationListData FindReservationListData(ReservationId reservationId)
        {
            var whereClause = @"where reservation.id = @id";

            var parameter = new { id = reservationId.Value };

            return QueryObject<ReservationListData>(GetQuery(GetReservationListDataQuery, whereClause), parameter);
        }
    }
}

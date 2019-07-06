using System;
using System.Collections.Generic;
using System.Text;
using EquipmentReservation.Application.Reservations.Data;

namespace EquipmentReservation.Application.Reservations
{
    public class ReservationQueryService : IReservationQueryService
    {
        private readonly IQueryableRepository _queryableRepository;

        public ReservationQueryService(IQueryableRepository queryableRepository)
        {
            _queryableRepository = queryableRepository ?? throw new ArgumentNullException(nameof(queryableRepository));
        }

        public IEnumerable<ReservationData> GetAllReservation()
        {
            var query = @"
                select
                    reservation.RESERVATION_KEY as Id,
                    equipment.EQUIPMENT_KEY as EquipmentId,
                    equipment.EQUIPMENT_TYPE as EquipmentType,
                    equipment.NAME as EquipmentName,
                    account.ACCOUNT_KEY as AccuntId,
                    account.NAME as AccountName,
                    reservation.START_DATE_TIME as StartDateTime,
                    reservation.END_DATE_TIME as EndDateTime,
                    reservation.PURPOSE_OF_USE as PurposeOfUse
                from
                    T_RESERVATION reservation
                    join M_ACCOUNT account on reservation.ACCOUNT_KEY = account.ACCOUNT_KEY,
                    join M_EQUIPMENT equipment on reservation.EQUIPMENT_KEY = equipment.EQUIPMENT_KEY
                order by
                    reservation.START_DATE_TIME,
                    reservation.RESERVATION_KEY
                ";
            return _queryableRepository.QueryObjects<ReservationData>(query);
        }
    }
}

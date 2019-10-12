using EquipmentReservation.Application.Reservations.Data;
using System.Collections.Generic;

namespace EquipmentReservation.Application.Reservations.Queries
{
    public class GetAllReservationListDataResponse
    {
        public IEnumerable<ReservationListData> ReservationListDataList { get; set; }
    }
}

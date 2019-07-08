using EquipmentReservation.Application.Reservations.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace EquipmentReservation.Application.Reservations.Queries
{
    public class GetAllReservationListDataResponse
    {
        public IEnumerable<ReservationListData> ReservationListDataList { get; set; }
    }
}

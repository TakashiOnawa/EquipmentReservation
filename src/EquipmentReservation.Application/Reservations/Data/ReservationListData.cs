using System;
using System.Collections.Generic;
using System.Text;

namespace EquipmentReservation.Application.Reservations.Data
{
    public class ReservationListData : ReservationData
    {
        public int EquipmentType { get; set; }
        public string EquipmentName { get; set; }
        public string AccountName { get; set; }
    }
}

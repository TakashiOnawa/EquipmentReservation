using System;
using System.Collections.Generic;
using System.Text;

namespace EquipmentReservation.Domain.Reservations
{
    public class ReservationDateTime
    {
        public ReservationDateTime(DateTime from, DateTime to)
        {
            From = from;
            To = to;
        }

        public DateTime From { get; private set; }
        public DateTime To { get; private set; }
    }
}

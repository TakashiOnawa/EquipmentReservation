using System;
using System.Collections.Generic;
using System.Text;
using EquipmentReservation.Framework.Domain;

namespace EquipmentReservation.Domain.Reservations
{
    public class ReservatiionId : Identity
    {
        public ReservatiionId() : base() { }

        public ReservatiionId(string id) : base(id) { }
    }
}

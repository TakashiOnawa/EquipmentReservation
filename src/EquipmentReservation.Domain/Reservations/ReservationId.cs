﻿using EquipmentReservation.Framework.Domain;

namespace EquipmentReservation.Domain.Reservations
{
    public class ReservationId : Identity
    {
        public ReservationId() : base() { }

        public ReservationId(string id) : base(id) { }
    }
}

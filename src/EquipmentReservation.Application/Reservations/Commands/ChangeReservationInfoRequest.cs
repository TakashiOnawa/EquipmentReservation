﻿using System;

namespace EquipmentReservation.Application.Reservations.Commands
{
    public class ChangeReservationInfoRequest
    {
        public string ReservationId { get; set; }
        public string EquipmentId { get; set; }
        public string AccountId { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string PurposeOfUse { get; set; }
    }
}

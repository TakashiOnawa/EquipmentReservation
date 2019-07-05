﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EquipmentReservation.Application.Reservations.Data
{
    public class ReservationData
    {
        public string Id { get; set; }
        public string EquipmentId { get; set; }
        public int EquipmentType { get; set; }
        public string EquipmentName { get; set; }
        public string AccountId { get; set; }
        public string AccountName { get; set; }
        public DateTime FromDateTime { get; set; }
        public DateTime ToDateTime { get; set; }
        public string Purpose { get; set; }
    }
}

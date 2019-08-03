﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace EquipmentReservation.Application.Reservations.Exceptions
{
    [Serializable]
    public class ReservationDupulicationException : Exception
    {
        public ReservationDupulicationException() { }
        public ReservationDupulicationException(string message) : base(message) { }
        public ReservationDupulicationException(string message, Exception inner) : base(message, inner) { }
        protected ReservationDupulicationException(
          SerializationInfo info,
          StreamingContext context) : base(info, context) { }
    }
}

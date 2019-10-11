using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace EquipmentReservation.Application.Reservations.Exceptions
{
    [Serializable]
    public class ReservationNotFoundException : Exception
    {
        public ReservationNotFoundException() { }
        public ReservationNotFoundException(string message) : base(message) { }
        public ReservationNotFoundException(string message, Exception inner) : base(message, inner) { }
        protected ReservationNotFoundException(
          SerializationInfo info,
          StreamingContext context) : base(info, context) { }
    }
}

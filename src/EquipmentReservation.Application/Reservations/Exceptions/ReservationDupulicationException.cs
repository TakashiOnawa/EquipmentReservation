using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace EquipmentReservation.Application.Reservations.Exceptions
{
    public class ReservationDupulicationException : Exception
    {
        public ReservationDupulicationException()
        {
        }

        public ReservationDupulicationException(string message) : base(message)
        {
        }

        public ReservationDupulicationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ReservationDupulicationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}

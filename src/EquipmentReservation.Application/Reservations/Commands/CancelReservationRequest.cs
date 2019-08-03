using System;
using System.Collections.Generic;
using System.Text;

namespace EquipmentReservation.Application.Reservations.Commands
{
    public class CancelReservationRequest
    {
        public string ReservationId { get; set; }
    }
}

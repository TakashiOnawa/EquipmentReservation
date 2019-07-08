using System;
using System.Collections.Generic;
using System.Text;

namespace EquipmentReservation.Application.Reservations.Commands
{
    public class ChangeReservationInfoRequest
    {
        public string Id { get; set; }
        public string EquipmentId { get; set; }
        public string AccountId { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string PurposeOfUse { get; set; }
    }
}

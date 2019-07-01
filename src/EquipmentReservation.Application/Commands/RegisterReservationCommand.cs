using System;
using System.Collections.Generic;
using System.Text;

namespace EquipmentReservation.Application.Commands
{
    public class RegisterReservationCommand
    {
        public string EquipmentId { get; set; }
        public string AccountId { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}

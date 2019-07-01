using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EquipmentReservation.Models
{
    public class ReservationViewModel
    {
        public string Id { get; set; }
        public EquipmentViewModel Equipment { get; set; }
        public AccountViewModel Account { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime FromTime { get; set; }
        public DateTime ToDate { get; set; }
        public DateTime ToTime { get; set; }
        public string Purpose { get; set; }

        public DateTime FromDateTime()
        {
            return FromDate;
        }

        public DateTime ToDateTime()
        {
            return ToDate;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EquipmentReservation.Models
{
    public class ReservationViewModel
    {
        public string Id { get; set; }
        public EquipmentViewModel Equipment { get; set; }
        public AccountViewModel Account { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? FromTime { get; set; }
        public DateTime? ToDate { get; set; }
        public DateTime? ToTime { get; set; }
        public string Purpose { get; set; }

        public DateTime? GetFromDateTime()
        {
            return CombineDateTime(FromDate, FromTime);
        }

        public DateTime? GetToDateTime()
        {
            return CombineDateTime(ToDate, ToTime);
        }

        private DateTime? CombineDateTime(DateTime? date, DateTime? time)
        {
            if (!date.HasValue || !time.HasValue) return null;
            return date.Value.Date + time.Value.TimeOfDay;
        }
    }
}

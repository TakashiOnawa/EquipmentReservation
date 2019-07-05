using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using EquipmentReservation.Application.Accounts.Data;
using EquipmentReservation.Application.Equipments.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EquipmentReservation.Models
{
    public class ReservationViewModel
    {
        public string Id { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? FromTime { get; set; }
        public DateTime? ToDate { get; set; }
        public DateTime? ToTime { get; set; }
        public string Purpose { get; set; }

        public string SelectedAccountId { get; set; }
        public IEnumerable<AccountData> AccountList { get; set; }

        public string SelectedEquipmentId { get; set; }
        public IEnumerable<EquipmentData> EquipmentList { get; set; }

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

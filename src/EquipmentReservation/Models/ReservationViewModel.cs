using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using EquipmentReservation.Application.Accounts.Data;
using EquipmentReservation.Application.Equipments.Data;
using EquipmentReservation.Validations;

namespace EquipmentReservation.Models
{
    public class ReservationViewModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "利用者は必須入力です。")]
        public string SelectedAccountId { get; set; }
        public IEnumerable<AccountData> AccountList { get; set; }

        [Required(ErrorMessage = "備品は必須入力です。")]
        public string SelectedEquipmentId { get; set; }
        public IEnumerable<EquipmentData> EquipmentList { get; set; }

        [Required(ErrorMessage = "利用開始日付は必須入力です。")]
        public DateTime? StartDate { get; set; }
        [Required(ErrorMessage = "利用開始時間は必須入力です。")]
        public DateTime? StartTime { get; set; }

        [Required(ErrorMessage = "利用終了日付は必須入力です。")]
        public DateTime? EndDate { get; set; }
        [Required(ErrorMessage = "利用終了時間は必須入力です。")]
        [StartEndDateTimeValidation(
            StartDatePropertyName = nameof(StartDate), 
            StartTimePropertyName = nameof(StartTime), 
            EndDatePropertyName = nameof(EndDate), 
            ErrorMessage = "利用終了日時は利用開始日時よりも後にしてください。")]
        public DateTime? EndTime { get; set; }

        [StringLength(64, ErrorMessage = "利用目的は {1} 文字以内で入力してください。")]
        public string PurposeOfUse { get; set; }

        public bool IsReadOnly { get; set; }

        public DateTime? GetStartDateTime()
        {
            return CombineDateTime(StartDate, StartTime);
        }
       
        public DateTime? GetEndDateTime()
        {
            return CombineDateTime(EndDate, EndTime);
        }

        private DateTime? CombineDateTime(DateTime? date, DateTime? time)
        {
            if (!date.HasValue || !time.HasValue) return null;
            return date.Value.Date + time.Value.TimeOfDay;
        }
    }
}

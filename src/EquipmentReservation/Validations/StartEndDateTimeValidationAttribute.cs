using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EquipmentReservation.Validations
{
    public class StartEndDateTimeValidationAttribute : ValidationAttribute
    {
        public string StartDatePropertyName { get; set; }
        public string StartTimePropertyName { get; set; }
        public string EndDatePropertyName { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var startDate = GetDateTime(validationContext, StartDatePropertyName);
            var startTime = GetDateTime(validationContext, StartTimePropertyName);
            var endDate = GetDateTime(validationContext, EndDatePropertyName);
            var endTime = value as DateTime?;

            if (!startDate.HasValue || !startTime.HasValue || !endDate.HasValue || !endTime.HasValue)
                return ValidationResult.Success;

            var startDateTime = CombineDateTime(startDate, startTime);
            var endDateTime = CombineDateTime(endDate, endTime);

            if (startDateTime.CompareTo(endDateTime) >= 0)
                return new ValidationResult(ErrorMessage, new string[] { validationContext.MemberName });

            return ValidationResult.Success;
        }

        private DateTime? GetDateTime(ValidationContext validationContext, string propertyName)
        {
            var property = validationContext.ObjectInstance.GetType().GetProperty(propertyName);
            if(property == null)
                throw new InvalidOperationException(string.Format("プロパティが定義されていません。 Name = {0}", propertyName));

            return property.GetValue(validationContext.ObjectInstance, null) as DateTime?;
        }

        private DateTime CombineDateTime(DateTime? date, DateTime? time)
        {
            return date.Value.Date + time.Value.TimeOfDay;
        }
    }
}

using System;

namespace EquipmentReservation.Framework.Domain
{
    public class Assertion
    {
        public static void ArgumentNotNull(object obj, string name = null, string message = null)
        {
            if(obj == null)
            {
                throw new ArgumentNullException(name, message);
            }
        }

        public static void ArgumentNotNullOrEmpty(string value, string name = null, string message = null)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(name, message);
            }
        }

        public static void ArgumentRange(string value, int max, string name = null, string message = null)
        {
            var target = value ?? string.Empty;
            if (target.Length >= max)
            {
                throw new ArgumentOutOfRangeException(name,
                    string.IsNullOrEmpty(message) ? string.Format("{0} 文字以内でなければなりません。", max) : message);
            }
        }
    }
}

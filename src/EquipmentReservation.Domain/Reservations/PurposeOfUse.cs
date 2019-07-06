using System;
using System.Collections.Generic;
using System.Text;

namespace EquipmentReservation.Domain.Reservations
{
    public class PurposeOfUse : IEquatable<PurposeOfUse>
    {
        public static readonly int MAX_LENGTH = 64;

        public PurposeOfUse(string purposeOfUse)
        {
            if (string.IsNullOrEmpty(purposeOfUse)) throw new ArgumentNullException(nameof(purposeOfUse));

            if (purposeOfUse.Length >= MAX_LENGTH)
                throw new ArgumentOutOfRangeException(nameof(purposeOfUse), string.Format("{0} 文字以内でなければなりません。", MAX_LENGTH));

            Value = purposeOfUse;
        }

        public string Value { get; private set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as PurposeOfUse);
        }

        public bool Equals(PurposeOfUse other)
        {
            return other != null &&
                   Value == other.Value;
        }

        public override int GetHashCode()
        {
            return -1937169414 + EqualityComparer<string>.Default.GetHashCode(Value);
        }
    }
}

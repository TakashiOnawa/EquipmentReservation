using EquipmentReservation.Framework.Domain;
using System.Collections.Generic;

namespace EquipmentReservation.Domain.Reservations
{
    public class PurposeOfUse : IValueObject
    {
        public PurposeOfUse(string value)
        {
            Assertion.ArgumentRange(value, 64, nameof(PurposeOfUse));
            Value = value;
        }

        public string Value { get; }

        public override bool Equals(object obj)
        {
            var use = obj as PurposeOfUse;
            return use != null &&
                   Value == use.Value;
        }

        public override int GetHashCode()
        {
            return -1937169414 + EqualityComparer<string>.Default.GetHashCode(Value);
        }

        public static bool operator ==(PurposeOfUse use1, PurposeOfUse use2)
        {
            return EqualityComparer<PurposeOfUse>.Default.Equals(use1, use2);
        }

        public static bool operator !=(PurposeOfUse use1, PurposeOfUse use2)
        {
            return !(use1 == use2);
        }
    }
}

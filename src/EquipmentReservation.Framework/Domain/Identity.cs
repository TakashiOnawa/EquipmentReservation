using System;
using System.Collections.Generic;

namespace EquipmentReservation.Framework.Domain
{
    public abstract class Identity : IValueObject<Identity>
    {
        public Identity()
        {
            Value = Guid.NewGuid().ToString();
        }

        public Identity(string id)
        {
            Assertion.ArgumentNotNullOrEmpty(id, nameof(id));
            Value = id;
        }

        public string Value { get; }

        public override bool Equals(object obj)
        {
            return Equals(obj as Identity);
        }

        public bool Equals(Identity other)
        {
            return other != null &&
                   Value == other.Value;
        }

        public override int GetHashCode()
        {
            return -1937169414 + EqualityComparer<string>.Default.GetHashCode(Value);
        }

        public static bool operator ==(Identity identity1, Identity identity2)
        {
            return EqualityComparer<Identity>.Default.Equals(identity1, identity2);
        }

        public static bool operator !=(Identity identity1, Identity identity2)
        {
            return !(identity1 == identity2);
        }
    }
}

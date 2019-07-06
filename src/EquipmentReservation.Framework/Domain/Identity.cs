using System;
using System.Collections.Generic;
using System.Text;

namespace EquipmentReservation.Framework.Domain
{
    public abstract class Identity : IEquatable<Identity>
    {
        public Identity()
        {
            Value = Guid.NewGuid().ToString();
        }

        public Identity(string id)
        {
            if (string.IsNullOrEmpty(id)) throw new ArgumentNullException(nameof(id));
            Value = id;
        }

        public string Value { get; private set; }

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
            return 2108858624 + EqualityComparer<string>.Default.GetHashCode(Value);
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

using System;
using System.Collections.Generic;
using System.Text;

namespace EquipmentReservation.Domain.Equipments
{
    public class EquipmentName : IEquatable<EquipmentName>
    {
        public EquipmentName(string name)
        {
            Value = name ?? throw new ArgumentNullException(nameof(name));
        }

        public string Value { get; private set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as EquipmentName);
        }

        public bool Equals(EquipmentName other)
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

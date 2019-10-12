using EquipmentReservation.Framework.Domain;
using System;

namespace EquipmentReservation.Domain.Equipments
{
    public class Equipment : IEquatable<Equipment>
    {
        public Equipment(EquipmentId id, EquipmentTypes equipmentType, string name)
        {
            Id = id;
            EquipmentType = equipmentType;
            Name = name;
        }

        private EquipmentId _id;
        public EquipmentId Id
        {
            get { return _id; }
            private set
            {
                Assertion.ArgumentNotNull(value, nameof(Id));
                _id = value;
            }
        }

        public EquipmentTypes EquipmentType { get; private set; }

        private string _name;
        public string Name
        {
            get { return _name; }
            private set
            {
                Assertion.ArgumentNotNull(value, nameof(Name));
                Assertion.ArgumentRange(value, 64, nameof(Name));
                _name = value;
            }
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Equipment);
        }

        public bool Equals(Equipment other)
        {
            return other != null && Id.Equals(other.Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}

using EquipmentReservation.Framework.Domain;
using System.Collections.Generic;

namespace EquipmentReservation.Domain.Equipments
{
    public class Equipment : IEntity
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
            var equipment = obj as Equipment;
            return equipment != null &&
                   EqualityComparer<EquipmentId>.Default.Equals(Id, equipment.Id);
        }

        public override int GetHashCode()
        {
            return 2108858624 + EqualityComparer<EquipmentId>.Default.GetHashCode(Id);
        }

        public static bool operator ==(Equipment equipment1, Equipment equipment2)
        {
            return EqualityComparer<Equipment>.Default.Equals(equipment1, equipment2);
        }

        public static bool operator !=(Equipment equipment1, Equipment equipment2)
        {
            return !(equipment1 == equipment2);
        }
    }
}

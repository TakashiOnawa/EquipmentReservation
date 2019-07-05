using System;
using System.Collections.Generic;
using System.Text;

namespace EquipmentReservation.Domain.Equipments
{
    public class Equipment
    {
        public Equipment(EquipmentId id, EquipmentTypes equipmentType, EquipmentName name)
        {
            Id = id ?? throw new ArgumentNullException(nameof(id));
            EquipmentType = equipmentType;
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public EquipmentId Id { get; private set; }
        public EquipmentTypes EquipmentType { get; private set; }
        public EquipmentName Name { get; private set; }
    }
}

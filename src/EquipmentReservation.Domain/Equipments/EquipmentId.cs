using EquipmentReservation.Framework.Domain;

namespace EquipmentReservation.Domain.Equipments
{
    public class EquipmentId : Identity
    {
        public EquipmentId() : base() { }
        public EquipmentId(string id) : base(id) { }
    }
}

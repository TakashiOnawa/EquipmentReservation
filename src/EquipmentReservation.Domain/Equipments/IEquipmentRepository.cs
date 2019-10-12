using System.Collections.Generic;

namespace EquipmentReservation.Domain.Equipments
{
    public interface IEquipmentRepository
    {
        IEnumerable<Equipment> FindAll();
    }
}

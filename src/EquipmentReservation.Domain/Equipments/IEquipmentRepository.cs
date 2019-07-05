using System;
using System.Collections.Generic;
using System.Text;

namespace EquipmentReservation.Domain.Equipments
{
    public interface IEquipmentRepository
    {
        IEnumerable<Equipment> FindAll();
    }
}

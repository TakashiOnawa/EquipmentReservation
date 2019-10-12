using EquipmentReservation.Application.Equipments.Data;
using System.Collections.Generic;

namespace EquipmentReservation.Application.Equipments.Queries
{
    public interface IEquipmentDataQuery
    {
        IEnumerable<EquipmentData> FindAllEquipmentData();
    }
}

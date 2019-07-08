using EquipmentReservation.Application.Equipments.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace EquipmentReservation.Application.Equipments.Queries
{
    public interface IEquipmentDataQuery
    {
        IEnumerable<EquipmentData> FindAllEquipmentData();
    }
}

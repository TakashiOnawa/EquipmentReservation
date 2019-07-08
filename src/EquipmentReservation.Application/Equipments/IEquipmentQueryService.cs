using EquipmentReservation.Application.Equipments.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace EquipmentReservation.Application.Equipments
{
    public interface IEquipmentQueryService
    {
        GetAllEquipmentDataResponse GetAllEquipmentData();
    }
}

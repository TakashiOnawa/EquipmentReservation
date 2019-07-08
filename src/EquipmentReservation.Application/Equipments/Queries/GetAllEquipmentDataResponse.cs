using EquipmentReservation.Application.Equipments.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace EquipmentReservation.Application.Equipments.Queries
{
    public class GetAllEquipmentDataResponse
    {
        public IEnumerable<EquipmentData> EquipmentDataList { get; set; }
    }
}

using EquipmentReservation.Application.Equipments.Data;
using System.Collections.Generic;

namespace EquipmentReservation.Application.Equipments.Queries
{
    public class GetAllEquipmentDataResponse
    {
        public IEnumerable<EquipmentData> EquipmentDataList { get; set; }
    }
}

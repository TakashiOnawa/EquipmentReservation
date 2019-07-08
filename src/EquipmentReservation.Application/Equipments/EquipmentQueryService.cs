using EquipmentReservation.Application.Equipments.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace EquipmentReservation.Application.Equipments
{
    public class EquipmentQueryService : IEquipmentQueryService
    {
        private readonly IEquipmentDataQuery _equipmentDataQuery;

        public EquipmentQueryService(IEquipmentDataQuery equipmentDataQuery)
        {
            _equipmentDataQuery = equipmentDataQuery ?? throw new ArgumentNullException(nameof(equipmentDataQuery));
        }

        public GetAllEquipmentDataResponse GetAllEquipmentData()
        {
            return new GetAllEquipmentDataResponse()
            {
                EquipmentDataList = _equipmentDataQuery.FindAllEquipmentData()
            };
        }
    }
}

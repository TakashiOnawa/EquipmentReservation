using EquipmentReservation.Application.Equipments.Data;
using EquipmentReservation.Application.Equipments.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace EquipmentReservation.Infrastructure.Application.Repositories
{
    public class EquipmentDataQuery : IEquipmentDataQuery
    {
        private string GetQuery(string baseQuery, string whereClause = null)
        {
            return string.Format(baseQuery, whereClause);
        }

        private const string GetEquipmentDataQuery = @"
                select
                    equipment.EQUIPMENT_KEY as Id,
                    equipment.EQUIPMENT_TYPE as Type,
                    equipment.NAME as Name
                from
                    M_EQUIPMENT equipment
                {0}
                order by
                    equipment.EQUIPMENT_TYPE,
                    equipment.NAME;
                ";

        public IEnumerable<EquipmentData> FindAllEquipmentData()
        {
            var equipmentDataList = new List<EquipmentData>();
            foreach (var equipment in Domain.Repositories.EquipmentRepository._data)
            {
                equipmentDataList.Add(new EquipmentData()
                {
                    Id = equipment.Id.Value,
                    Type = (int)equipment.EquipmentType,
                    Name = equipment.Name
                });
            }
            return equipmentDataList;

            return new QueryableRepository().QueryObjects<EquipmentData>(GetQuery(GetEquipmentDataQuery));
        }
    }
}

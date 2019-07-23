using EquipmentReservation.Application.Equipments.Data;
using EquipmentReservation.Application.Equipments.Queries;
using EquipmentReservation.Infrastructure.Application.Repositories.Commons;
using EquipmentReservation.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace EquipmentReservation.Infrastructure.Application.Repositories
{
    public class EquipmentDataQuery : QueryableRepository, IEquipmentDataQuery
    {
        public EquipmentDataQuery(MyDbContext dbContext) : base(dbContext) { }

        private string GetQuery(string baseQuery, string whereClause = null)
        {
            return string.Format(baseQuery, whereClause);
        }

        private const string GetEquipmentDataQuery = @"
                select
                    id as Id,
                    equipment_type as EquipmentType,
                    equipment_name as EquipmentName
                from
                    equipments
                {0}
                order by
                    equipment_type,
                    equipment_name;
                ";

        public IEnumerable<EquipmentData> FindAllEquipmentData()
        {
            return QueryObjects<EquipmentData>(GetQuery(GetEquipmentDataQuery));
        }
    }
}

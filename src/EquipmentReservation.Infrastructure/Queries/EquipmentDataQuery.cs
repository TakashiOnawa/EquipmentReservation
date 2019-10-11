using EquipmentReservation.Application.Equipments.Data;
using EquipmentReservation.Application.Equipments.Queries;
using EquipmentReservation.Infrastructure.Database;
using System;
using System.Collections.Generic;

namespace EquipmentReservation.Infrastructure.Queries
{
    public class EquipmentDataQuery : IEquipmentDataQuery
    {
        private readonly MyDbContext _dbContext;

        public EquipmentDataQuery(MyDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

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
            return _dbContext.QueryObjects<EquipmentData>(GetQuery(GetEquipmentDataQuery));
        }
    }
}

using Dapper;
using EquipmentReservation.Application.Equipments.Data;
using EquipmentReservation.Application.Equipments.Queries;
using EquipmentReservation.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EquipmentReservation.Infrastructure.Application.Repositories
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
            return _dbContext.Database.GetDbConnection().Query<EquipmentData>(GetQuery(GetEquipmentDataQuery));
        }
    }
}

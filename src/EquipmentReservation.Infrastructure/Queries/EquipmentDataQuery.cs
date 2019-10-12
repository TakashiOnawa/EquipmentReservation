using EquipmentReservation.Application.Equipments.Data;
using EquipmentReservation.Application.Equipments.Queries;
using EquipmentReservation.Infrastructure.Database;
using EquipmentReservation.Infrastructure.Database.Tables;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EquipmentReservation.Infrastructure.Queries
{
    public class EquipmentDataQuery : IEquipmentDataQuery
    {
        private readonly MyDbContext _dbContext;

        public EquipmentDataQuery(MyDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public IEnumerable<EquipmentData> FindAllEquipmentData()
        {
            return _dbContext.Equipments.Select(_ => CreateEquipmentData(_)).ToArray();
        }

        private EquipmentData CreateEquipmentData(EQUIPMENTS equipment)
        {
            return new EquipmentData()
            {
                Id = equipment.id,
                EquipmentType = equipment.equipment_type,
                EquipmentName = equipment.equipment_name
            };
        }
    }
}

using EquipmentReservation.Domain.Equipments;
using EquipmentReservation.Infrastructure.Database;
using EquipmentReservation.Infrastructure.Database.Tables;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EquipmentReservation.Infrastructure.Repositories
{
    public class EquipmentRepository : IEquipmentRepository
    {
        private readonly MyDbContext _dbContext;

        public EquipmentRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public IEnumerable<Equipment> FindAll()
        {
            return _dbContext.Equipments.Select(_ => Create(_)).ToArray();
        }

        private Equipment Create(EQUIPMENTS equipment)
        {
            return new Equipment(
                new EquipmentId(equipment.id),
                (EquipmentTypes)equipment.equipment_type,
                equipment.equipment_name);
        }
    }
}

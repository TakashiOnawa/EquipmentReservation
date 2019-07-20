using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EquipmentReservation.Domain.Equipments;
using EquipmentReservation.Infrastructure.Database;

namespace EquipmentReservation.Infrastructure.Domain.Repositories
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
            return _dbContext.Equipments.Select(_ => new Equipment(new EquipmentId(_.id), (EquipmentTypes)_.equipment_type, _.equipment_name)).ToArray();
        }
    }
}

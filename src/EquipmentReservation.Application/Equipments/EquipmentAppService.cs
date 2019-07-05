using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EquipmentReservation.Application.Equipments.Data;
using EquipmentReservation.Domain.Equipments;

namespace EquipmentReservation.Application.Equipments
{
    public class EquipmentAppService : IEquipmentAppService
    {
        private readonly IEquipmentRepository _equipmentRepository;

        public EquipmentAppService(IEquipmentRepository equipmentRepository)
        {
            _equipmentRepository = equipmentRepository ?? throw new ArgumentNullException(nameof(equipmentRepository));
        }

        public IEnumerable<EquipmentData> GetAllEquipment()
        {
            return _equipmentRepository.FindAll().
                Select(_ => new EquipmentData() { Id = _.Id.Value, Name = _.Name.Value, Type = (int)_.EquipmentType }).ToArray();
        }
    }
}

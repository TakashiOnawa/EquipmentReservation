using System;
using System.Collections.Generic;
using System.Text;
using EquipmentReservation.Domain.Equipments;

namespace EquipmentReservation.Infrastructure.Domain.Repositories
{
    public class EquipmentRepository : IEquipmentRepository
    {
        private readonly List<Equipment> _data = new List<Equipment>();

        public EquipmentRepository()
        {
            _data.Add(new Equipment(new EquipmentId(), EquipmentTypes.USB, new EquipmentName("USB1")));
            _data.Add(new Equipment(new EquipmentId(), EquipmentTypes.USB, new EquipmentName("USB2")));
            _data.Add(new Equipment(new EquipmentId(), EquipmentTypes.PocketWifi, new EquipmentName("ポケットWifi1")));
            _data.Add(new Equipment(new EquipmentId(), EquipmentTypes.PocketWifi, new EquipmentName("ポケットWifi2")));
            _data.Add(new Equipment(new EquipmentId(), EquipmentTypes.CellPhone, new EquipmentName("携帯電話1")));
            _data.Add(new Equipment(new EquipmentId(), EquipmentTypes.CellPhone, new EquipmentName("携帯電話2")));
        }

        public IEnumerable<Equipment> FindAll()
        {
            return _data;
        }
    }
}

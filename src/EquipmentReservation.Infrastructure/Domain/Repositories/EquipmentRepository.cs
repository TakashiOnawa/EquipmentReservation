using System;
using System.Collections.Generic;
using System.Text;
using EquipmentReservation.Domain.Equipments;

namespace EquipmentReservation.Infrastructure.Domain.Repositories
{
    public class EquipmentRepository : IEquipmentRepository
    {
        public static List<Equipment> _data = new List<Equipment>();

        static EquipmentRepository()
        {
            _data.Add(new Equipment(new EquipmentId(), EquipmentTypes.USB, "USB1"));
            _data.Add(new Equipment(new EquipmentId(), EquipmentTypes.USB, "USB2"));
            _data.Add(new Equipment(new EquipmentId(), EquipmentTypes.PocketWifi, "ポケットWifi1"));
            _data.Add(new Equipment(new EquipmentId(), EquipmentTypes.PocketWifi, "ポケットWifi2"));
            _data.Add(new Equipment(new EquipmentId(), EquipmentTypes.CellPhone, "携帯電話1"));
            _data.Add(new Equipment(new EquipmentId(), EquipmentTypes.CellPhone, "携帯電話2"));
        }

        public IEnumerable<Equipment> FindAll()
        {
            return _data;
        }
    }
}

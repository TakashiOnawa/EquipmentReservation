using System;
using System.Collections.Generic;
using System.Text;
using EquipmentReservation.Domain.Equipments;
using EquipmentReservation.Domain.Reservations;

namespace EquipmentReservation.Infrastructure.Domain.Reservations
{
    public class ReservationRepository : IReservationRepository
    {
        public IEnumerable<Reservation> FindByEquipmentId(EquipmentId equipmentId)
        {
            return new List<Reservation>();
        }

        public void Save(Reservation entity)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using EquipmentReservation.Domain.Equipments;

namespace EquipmentReservation.Domain.Reservations
{
    public interface IReservationRepository
    {
        Reservation Find(ReservationId reservationId);
        IEnumerable<Reservation> FindByEquipmentId(EquipmentId equipmentId);
        void Save(Reservation entity);
        void Lock();
    }
}

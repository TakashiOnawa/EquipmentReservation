using EquipmentReservation.Domain.Equipments;
using System.Collections.Generic;

namespace EquipmentReservation.Domain.Reservations
{
    public interface IReservationRepository
    {
        Reservation Find(ReservationId reservationId, ReservationStatus? reservationStatus = null);
        IEnumerable<Reservation> FindByEquipmentId(EquipmentId equipmentId, ReservationStatus? reservationStatus = null);
        void Save(Reservation entity);
        void Lock();
    }
}

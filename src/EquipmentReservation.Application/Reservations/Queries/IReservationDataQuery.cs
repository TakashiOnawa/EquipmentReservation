using EquipmentReservation.Application.Reservations.Data;
using EquipmentReservation.Domain.Reservations;
using System.Collections.Generic;

namespace EquipmentReservation.Application.Reservations.Queries
{
    public interface IReservationDataQuery
    {
        ReservationData FindReservationData(ReservationId reservationId);

        IEnumerable<ReservationListData> FindAllReservationListData();
        ReservationListData FindReservationListData(ReservationId reservationId);
    }
}

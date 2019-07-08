using EquipmentReservation.Application.Reservations.Data;
using EquipmentReservation.Domain.Reservations;
using System;
using System.Collections.Generic;
using System.Text;

namespace EquipmentReservation.Application.Reservations.Queries
{
    public interface IReservationDataQuery
    {
        IEnumerable<ReservationData> FindAllReservationData();
        ReservationData FindReservationData(ReservationId reservationId);

        IEnumerable<ReservationListData> FindAllReservationListData();
        ReservationListData FindReservationListData(ReservationId reservationId);
    }
}

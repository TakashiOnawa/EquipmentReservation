using System;
using System.Collections.Generic;
using System.Text;
using EquipmentReservation.Application.Reservations.Data;

namespace EquipmentReservation.Application.Reservations
{
    public interface IReservationQueryService
    {
        IEnumerable<ReservationData> GetAllReservation();
    }
}

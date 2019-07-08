using System;
using System.Collections.Generic;
using System.Text;
using EquipmentReservation.Application.Reservations.Data;
using EquipmentReservation.Application.Reservations.Queries;
using EquipmentReservation.Domain.Reservations;

namespace EquipmentReservation.Application.Reservations
{
    public interface IReservationQueryService
    {
        GetReservationDataResponse GetReservationData(GetReservationDataRequest request);

        GetAllReservationListDataResponse GetAllReservationListData();
        GetReservationListDataResponse GetReservationListData(GetReservationListDataRequest request);
    }
}

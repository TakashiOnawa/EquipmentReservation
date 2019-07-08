using System;
using System.Collections.Generic;
using System.Text;
using EquipmentReservation.Application.Reservations.Data;
using EquipmentReservation.Application.Reservations.Queries;
using EquipmentReservation.Domain.Reservations;

namespace EquipmentReservation.Application.Reservations
{
    public class ReservationQueryService : IReservationQueryService
    {
        private readonly IReservationDataQuery _reservationDataQuery;

        public ReservationQueryService(IReservationDataQuery reservationDataQuery)
        {
            _reservationDataQuery = reservationDataQuery ?? throw new ArgumentNullException(nameof(reservationDataQuery));
        }

        public GetReservationDataResponse GetReservationData(GetReservationDataRequest request)
        {
            return new GetReservationDataResponse()
            {
                ReservationData = _reservationDataQuery.FindReservationData(new ReservationId(request.ReservationId))
            };
        }

        public GetAllReservationListDataResponse GetAllReservationListData()
        {
            return new GetAllReservationListDataResponse()
            {
                ReservationListDataList = _reservationDataQuery.FindAllReservationListData()
            };
        }

        public GetReservationListDataResponse GetReservationListData(GetReservationListDataRequest request)
        {
            return new GetReservationListDataResponse()
            {
                ReservationListData = _reservationDataQuery.FindReservationListData(new ReservationId(request.ReservationId))
            };
        }
    }
}

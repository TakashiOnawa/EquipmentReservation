using System;
using System.Collections.Generic;
using System.Text;
using EquipmentReservation.Application.Reservations.Queries;
using EquipmentReservation.Domain.Reservations;

namespace EquipmentReservation.Application.Reservations
{
    public class ReservationQueryService : IReservationQueryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReservationQueryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public GetReservationDataResponse GetReservationData(GetReservationDataRequest request)
        {
            return new GetReservationDataResponse()
            {
                ReservationData = _unitOfWork.ReservationDataQuery.FindReservationData(new ReservationId(request.ReservationId))
            };
        }

        public GetAllReservationListDataResponse GetAllReservationListData()
        {
            return new GetAllReservationListDataResponse()
            {
                ReservationListDataList = _unitOfWork.ReservationDataQuery.FindAllReservationListData()
            };
        }

        public GetReservationListDataResponse GetReservationListData(GetReservationListDataRequest request)
        {
            return new GetReservationListDataResponse()
            {
                ReservationListData = _unitOfWork.ReservationDataQuery.FindReservationListData(new ReservationId(request.ReservationId))
            };
        }
    }
}

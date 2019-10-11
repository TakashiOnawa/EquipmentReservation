using EquipmentReservation.Application.Reservations.Queries;
using EquipmentReservation.Domain.Reservations;
using System;

namespace EquipmentReservation.Application.Reservations
{
    public class ReservationQueryService : IReservationQueryService
    {
        private readonly IQueryFactory _queryFactory;

        public ReservationQueryService(IQueryFactory queryFactory)
        {
            _queryFactory = queryFactory ?? throw new ArgumentNullException(nameof(queryFactory));
        }

        public GetReservationDataResponse GetReservationData(GetReservationDataRequest request)
        {
            return new GetReservationDataResponse()
            {
                ReservationData = _queryFactory.ReservationDataQuery.FindReservationData(new ReservationId(request.ReservationId))
            };
        }

        public GetAllReservationListDataResponse GetAllReservationListData()
        {
            return new GetAllReservationListDataResponse()
            {
                ReservationListDataList = _queryFactory.ReservationDataQuery.FindAllReservationListData()
            };
        }

        public GetReservationListDataResponse GetReservationListData(GetReservationListDataRequest request)
        {
            return new GetReservationListDataResponse()
            {
                ReservationListData = _queryFactory.ReservationDataQuery.FindReservationListData(new ReservationId(request.ReservationId))
            };
        }
    }
}

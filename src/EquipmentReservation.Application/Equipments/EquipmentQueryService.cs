using EquipmentReservation.Application.Equipments.Queries;
using System;

namespace EquipmentReservation.Application.Equipments
{
    public class EquipmentQueryService : IEquipmentQueryService
    {
        private readonly IQueryFactory _queryFactory;

        public EquipmentQueryService(IQueryFactory queryFactory)
        {
            _queryFactory = queryFactory ?? throw new ArgumentNullException(nameof(queryFactory));
        }

        public GetAllEquipmentDataResponse GetAllEquipmentData()
        {
            return new GetAllEquipmentDataResponse()
            {
                EquipmentDataList = _queryFactory.EquipmentDataQuery.FindAllEquipmentData()
            };
        }
    }
}

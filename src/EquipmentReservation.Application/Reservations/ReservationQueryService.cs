using System;
using System.Collections.Generic;
using System.Text;
using EquipmentReservation.Application.Reservations.Data;

namespace EquipmentReservation.Application.Reservations
{
    public class ReservationQueryService : IReservationQueryService
    {
        private readonly IQueryableRepository _queryableRepository;

        public ReservationQueryService(IQueryableRepository queryableRepository)
        {
            _queryableRepository = queryableRepository ?? throw new ArgumentNullException(nameof(queryableRepository));
        }

        public IEnumerable<ReservationData> GetAllReservation()
        {
            var query = "select * from dual;";
            return _queryableRepository.QueryObjects<ReservationData>(query);
        }
    }
}

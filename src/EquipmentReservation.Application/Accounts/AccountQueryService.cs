using EquipmentReservation.Application.Accounts.Queries;
using System;

namespace EquipmentReservation.Application.Accounts
{
    public class AccountQueryService : IAccountQueryService
    {
        private readonly IQueryFactory _queryFactory;

        public AccountQueryService(IQueryFactory queryFactory)
        {
            _queryFactory = queryFactory ?? throw new ArgumentNullException(nameof(queryFactory));
        }

        public GetAllAccountDataResponse GetAllAccountData()
        {
            return new GetAllAccountDataResponse()
            {
                AccountDataList = _queryFactory.AccountDataQuery.GetAccountData()
            };
        }
    }
}

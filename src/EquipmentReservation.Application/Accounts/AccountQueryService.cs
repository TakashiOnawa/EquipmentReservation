using EquipmentReservation.Application.Accounts.Data;
using EquipmentReservation.Application.Accounts.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace EquipmentReservation.Application.Accounts
{
    public class AccountQueryService : IAccountQueryService
    {
        private readonly IAccountDataQuery _accountDataQuery;

        public AccountQueryService(IAccountDataQuery accountDataQuery)
        {
            _accountDataQuery = accountDataQuery ?? throw new ArgumentNullException(nameof(accountDataQuery));
        }

        public GetAllAccountDataResponse GetAllAccountData()
        {
            return new GetAllAccountDataResponse()
            {
                AccountDataList = _accountDataQuery.GetAccountData()
            };
        }
    }
}

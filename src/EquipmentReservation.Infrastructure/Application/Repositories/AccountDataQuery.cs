using EquipmentReservation.Application.Accounts.Data;
using EquipmentReservation.Application.Accounts.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace EquipmentReservation.Infrastructure.Application.Repositories
{
    public class AccountDataQuery : IAccountDataQuery
    {
        private string GetQuery(string baseQuery, string whereClause = null)
        {
            return string.Format(baseQuery, whereClause);
        }

        private const string GetAccountDataQuery = @"
                select
                    account.ACCOUNT_KEY as Id,
                    account.NAME as Name
                from
                    M_ACCOUNT account
                {0}
                order by
                    account.NAME;
                ";

        public IEnumerable<AccountData> GetAccountData()
        {
            var accountDataList = new List<AccountData>();
            foreach(var account in Domain.Repositories.AccountRepository._data)
            {
                accountDataList.Add(new AccountData()
                {
                    Id = account.Id.Value,
                    Name = account.Name
                });
            }

            return accountDataList;

            return new QueryableRepository().QueryObjects<AccountData>(GetQuery(GetAccountDataQuery));
        }

    }
}

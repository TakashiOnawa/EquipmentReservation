using EquipmentReservation.Application.Accounts.Data;
using EquipmentReservation.Application.Accounts.Queries;
using EquipmentReservation.Infrastructure.Application.Repositories.Commons;
using EquipmentReservation.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace EquipmentReservation.Infrastructure.Application.Repositories
{
    public class AccountDataQuery : QuerableRepository, IAccountDataQuery
    {
        public AccountDataQuery(MyDbContext dbContext) : base(dbContext) { }

        private string GetQuery(string baseQuery, string whereClause = null)
        {
            return string.Format(baseQuery, whereClause);
        }

        private const string GetAccountDataQuery = @"
                select
                    id as Id,
                    account_name as AccountName
                from
                    accounts
                {0}
                order by
                    account_name;
                ";

        public IEnumerable<AccountData> GetAccountData()
        {
            return QueryObjects<AccountData>(GetQuery(GetAccountDataQuery));
        }

    }
}

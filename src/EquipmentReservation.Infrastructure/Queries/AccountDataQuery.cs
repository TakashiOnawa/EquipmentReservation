using EquipmentReservation.Application.Accounts.Data;
using EquipmentReservation.Application.Accounts.Queries;
using EquipmentReservation.Infrastructure.Database;
using System;
using System.Collections.Generic;

namespace EquipmentReservation.Infrastructure.Queries
{
    public class AccountDataQuery : IAccountDataQuery
    {
        private readonly MyDbContext _dbContext;

        public AccountDataQuery(MyDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

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
            return _dbContext.QueryObjects<AccountData>(GetQuery(GetAccountDataQuery));
        }

    }
}

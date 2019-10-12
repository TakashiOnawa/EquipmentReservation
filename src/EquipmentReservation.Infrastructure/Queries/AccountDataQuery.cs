using EquipmentReservation.Application.Accounts.Data;
using EquipmentReservation.Application.Accounts.Queries;
using EquipmentReservation.Infrastructure.Database;
using EquipmentReservation.Infrastructure.Database.Tables;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EquipmentReservation.Infrastructure.Queries
{
    public class AccountDataQuery : IAccountDataQuery
    {
        private readonly MyDbContext _dbContext;

        public AccountDataQuery(MyDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public IEnumerable<AccountData> FindAllAccountData()
        {
            return _dbContext.Accounts.Select(_ => CreateAccountData(_)).ToArray();
        }

        private AccountData CreateAccountData(ACCOUNTS account)
        {
            return new AccountData()
            {
                Id = account.id,
                AccountName = account.account_name
            };
        }
    }
}

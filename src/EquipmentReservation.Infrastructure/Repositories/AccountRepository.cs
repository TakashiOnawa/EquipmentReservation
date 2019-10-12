using EquipmentReservation.Domain.Accounts;
using EquipmentReservation.Infrastructure.Database;
using EquipmentReservation.Infrastructure.Database.Tables;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EquipmentReservation.Infrastructure.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly MyDbContext _dbContext;

        public AccountRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public IEnumerable<Account> FindAll()
        {
            return _dbContext.Accounts.Select(_ => Create(_)).ToArray();
        }

        private Account Create(ACCOUNTS account)
        {
            return new Account(
                new AccountId(account.id),
                account.account_name);
        }
    }
}

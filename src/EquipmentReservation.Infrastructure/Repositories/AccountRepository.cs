using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EquipmentReservation.Domain.Accounts;
using EquipmentReservation.Infrastructure.Database;

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
            return _dbContext.Accounts.Select(_ => new Account(new AccountId(_.id), _.account_name)).ToArray();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using EquipmentReservation.Domain.Accounts;

namespace EquipmentReservation.Infrastructure.Domain.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly List<Account> _data = new List<Account>();

        public AccountRepository()
        {
            _data.Add(new Account(new AccountId(), new AccountName("アカウント1")));
            _data.Add(new Account(new AccountId(), new AccountName("アカウント2")));
            _data.Add(new Account(new AccountId(), new AccountName("アカウント3")));
        }

        public IEnumerable<Account> FindAll()
        {
            return _data;
        }
    }
}

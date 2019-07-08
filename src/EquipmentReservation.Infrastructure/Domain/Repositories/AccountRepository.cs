using System;
using System.Collections.Generic;
using System.Text;
using EquipmentReservation.Domain.Accounts;

namespace EquipmentReservation.Infrastructure.Domain.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        public static readonly List<Account> _data = new List<Account>();

        static AccountRepository()
        {
            _data.Add(new Account(new AccountId(), "アカウント1"));
            _data.Add(new Account(new AccountId(), "アカウント2"));
            _data.Add(new Account(new AccountId(), "アカウント3"));
        }

        public IEnumerable<Account> FindAll()
        {
            return _data;
        }
    }
}

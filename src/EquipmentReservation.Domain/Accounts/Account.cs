using System;
using System.Collections.Generic;
using System.Text;

namespace EquipmentReservation.Domain.Accounts
{
    public class Account
    {
        public Account(AccountId id, AccountName name)
        {
            Id = id ?? throw new ArgumentNullException(nameof(id));
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public AccountId Id { get; private set; }

        public AccountName Name { get; private set; }
    }
}

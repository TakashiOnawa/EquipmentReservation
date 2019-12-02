using EquipmentReservation.Framework.Domain;
using System.Collections.Generic;

namespace EquipmentReservation.Domain.Accounts
{
    public class Account : IEntity
    {
        public Account(AccountId id, string name)
        {
            Id = id;
            Name = name;
        }

        private AccountId _id;
        public AccountId Id
        {
            get { return _id; }
            private set
            {
                Assertion.ArgumentNotNull(value, nameof(Id));
                _id = value;
            }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            private set
            {
                Assertion.ArgumentNotNull(value, nameof(Name));
                Assertion.ArgumentRange(value, 64, nameof(Name));
                _name = value;
            }
        }

        public override bool Equals(object obj)
        {
            var account = obj as Account;
            return account != null &&
                   EqualityComparer<AccountId>.Default.Equals(Id, account.Id);
        }

        public override int GetHashCode()
        {
            return 2108858624 + EqualityComparer<AccountId>.Default.GetHashCode(Id);
        }

        public static bool operator ==(Account account1, Account account2)
        {
            return EqualityComparer<Account>.Default.Equals(account1, account2);
        }

        public static bool operator !=(Account account1, Account account2)
        {
            return !(account1 == account2);
        }
    }
}

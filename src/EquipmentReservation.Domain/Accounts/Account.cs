using EquipmentReservation.Framework.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace EquipmentReservation.Domain.Accounts
{
    public class Account : IEquatable<Account>
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
            return Equals(obj as Account);
        }

        public bool Equals(Account other)
        {
            return other != null && Id.Equals(other.Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}

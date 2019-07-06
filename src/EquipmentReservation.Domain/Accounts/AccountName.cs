using System;
using System.Collections.Generic;
using System.Text;

namespace EquipmentReservation.Domain.Accounts
{
    public class AccountName : IEquatable<AccountName>
    {
        public AccountName(string name)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException(nameof(name));
            Value = name;
        }

        public string Value { get; private set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as AccountName);
        }

        public bool Equals(AccountName other)
        {
            return other != null &&
                   Value == other.Value;
        }

        public override int GetHashCode()
        {
            return -1937169414 + EqualityComparer<string>.Default.GetHashCode(Value);
        }
    }
}

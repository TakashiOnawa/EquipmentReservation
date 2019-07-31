using EquipmentReservation.Domain.Accounts;
using EquipmentReservation.Framework.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace EquipmentReservation.Domain.Reservations
{
    public class Cancellation : IEquatable<Cancellation>
    {
        public Cancellation(AccountId accountId, DateTime cancellationDateTime)
        {
            Assertion.ArgumentNotNull(accountId);
        }

        public AccountId AccountId { get; private set; }
        public DateTime CancellationDateTime { get; private set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as Cancellation);
        }

        public bool Equals(Cancellation other)
        {
            return other != null &&
                   EqualityComparer<AccountId>.Default.Equals(AccountId, other.AccountId) &&
                   CancellationDateTime == other.CancellationDateTime;
        }

        public override int GetHashCode()
        {
            var hashCode = 1187301764;
            hashCode = hashCode * -1521134295 + EqualityComparer<AccountId>.Default.GetHashCode(AccountId);
            hashCode = hashCode * -1521134295 + CancellationDateTime.GetHashCode();
            return hashCode;
        }
    }
}

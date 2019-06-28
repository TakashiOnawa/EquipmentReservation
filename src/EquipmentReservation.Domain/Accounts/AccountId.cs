using System;
using System.Collections.Generic;
using System.Text;
using EquipmentReservation.Framework.Domain;

namespace EquipmentReservation.Domain.Accounts
{
    public class AccountId : Identity
    {
        public AccountId() : base() { }

        public AccountId(string id) : base(id) { }
    }
}

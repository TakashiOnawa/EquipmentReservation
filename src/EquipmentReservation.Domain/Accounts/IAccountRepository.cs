using System;
using System.Collections.Generic;
using System.Text;

namespace EquipmentReservation.Domain.Accounts
{
    public interface IAccountRepository
    {
        IEnumerable<Account> FindAll();
    }
}

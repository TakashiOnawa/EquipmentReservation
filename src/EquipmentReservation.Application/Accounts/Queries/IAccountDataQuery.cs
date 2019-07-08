using EquipmentReservation.Application.Accounts.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace EquipmentReservation.Application.Accounts.Queries
{
    public interface IAccountDataQuery
    {
        IEnumerable<AccountData> GetAccountData();
    }
}

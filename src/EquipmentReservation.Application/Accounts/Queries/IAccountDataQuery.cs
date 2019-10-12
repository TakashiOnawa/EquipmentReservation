using EquipmentReservation.Application.Accounts.Data;
using System.Collections.Generic;

namespace EquipmentReservation.Application.Accounts.Queries
{
    public interface IAccountDataQuery
    {
        IEnumerable<AccountData> FindAllAccountData();
    }
}

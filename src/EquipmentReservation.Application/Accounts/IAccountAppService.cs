using System;
using System.Collections.Generic;
using System.Text;
using EquipmentReservation.Application.Accounts.Data;
using EquipmentReservation.Domain.Accounts;

namespace EquipmentReservation.Application.Accounts
{
    public interface IAccountAppService
    {
        IEnumerable<AccountData> GetAllAccount();
    }
}

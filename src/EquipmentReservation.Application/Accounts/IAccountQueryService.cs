using EquipmentReservation.Application.Accounts.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace EquipmentReservation.Application.Accounts
{
    public interface IAccountQueryService
    {
        GetAllAccountDataResponse GetAllAccountData();
    }
}

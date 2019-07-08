using EquipmentReservation.Application.Accounts.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace EquipmentReservation.Application.Accounts.Queries
{
    public class GetAllAccountDataResponse
    {
        public IEnumerable<AccountData> AccountDataList { get; set; }
    }
}

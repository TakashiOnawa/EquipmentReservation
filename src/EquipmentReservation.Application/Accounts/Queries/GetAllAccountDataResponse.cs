using EquipmentReservation.Application.Accounts.Data;
using System.Collections.Generic;

namespace EquipmentReservation.Application.Accounts.Queries
{
    public class GetAllAccountDataResponse
    {
        public IEnumerable<AccountData> AccountDataList { get; set; }
    }
}

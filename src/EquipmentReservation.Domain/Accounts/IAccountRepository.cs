using System.Collections.Generic;

namespace EquipmentReservation.Domain.Accounts
{
    public interface IAccountRepository
    {
        IEnumerable<Account> FindAll();
    }
}

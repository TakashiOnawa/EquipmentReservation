using EquipmentReservation.Application.Accounts.Queries;

namespace EquipmentReservation.Application.Accounts
{
    public interface IAccountQueryService
    {
        GetAllAccountDataResponse GetAllAccountData();
    }
}

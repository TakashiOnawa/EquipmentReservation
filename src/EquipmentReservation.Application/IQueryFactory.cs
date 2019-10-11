using EquipmentReservation.Application.Accounts.Queries;
using EquipmentReservation.Application.Equipments.Queries;
using EquipmentReservation.Application.Reservations.Queries;

namespace EquipmentReservation.Application
{
    public interface IQueryFactory
    {
        IAccountDataQuery AccountDataQuery { get; }
        IEquipmentDataQuery EquipmentDataQuery { get; }
        IReservationDataQuery ReservationDataQuery { get; }
    }
}

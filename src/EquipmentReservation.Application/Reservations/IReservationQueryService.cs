using EquipmentReservation.Application.Reservations.Queries;

namespace EquipmentReservation.Application.Reservations
{
    public interface IReservationQueryService
    {
        GetReservationDataResponse GetReservationData(GetReservationDataRequest request);

        GetAllReservationListDataResponse GetAllReservationListData();
    }
}

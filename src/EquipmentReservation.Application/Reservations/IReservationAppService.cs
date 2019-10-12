using EquipmentReservation.Application.Reservations.Commands;

namespace EquipmentReservation.Application.Reservations
{
    public interface IReservationAppService
    {
        void RegisterReservation(RegisterReservationRequest request);
        void ChangeReservationInfo(ChangeReservationInfoRequest request);
        void CancelReservation(CancelReservationRequest request);
    }
}

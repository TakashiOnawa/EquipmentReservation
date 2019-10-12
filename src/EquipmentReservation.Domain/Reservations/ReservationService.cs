using EquipmentReservation.Framework.Domain;
using System.Linq;

namespace EquipmentReservation.Domain.Reservations
{
    public class ReservationService
    {
        private readonly IReservationRepository _reservationRepository;

        public ReservationService(IReservationRepository reservationRepository)
        {
            Assertion.ArgumentNotNull(reservationRepository, nameof(reservationRepository));
            _reservationRepository = reservationRepository;
        }

        public bool IsDupulicatedReservation(Reservation reservation)
        {
            Assertion.ArgumentNotNull(reservation, nameof(reservation));
            var reservations = _reservationRepository.FindByEquipmentId(reservation.EquipmentId, ReservationStatus.Reserved);
            return reservations.Where(_ => !_.Equals(reservation)).Any(_ => _.IsDupulicated(reservation));
        }
    }
}

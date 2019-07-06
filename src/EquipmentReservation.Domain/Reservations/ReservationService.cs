using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EquipmentReservation.Domain.Reservations
{
    public class ReservationService
    {
        private readonly IReservationRepository _reservationRepository;

        public ReservationService(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository ?? throw new ArgumentNullException(nameof(reservationRepository));
        }

        public bool IsDupulicateReservation(Reservation reservation)
        {
            if (reservation == null) throw new ArgumentNullException(nameof(reservation));

            var reservations = _reservationRepository.FindByEquipmentId(reservation.EquipmentId);

            return reservations.Any(_ => _.IsDupulicated(reservation));
        }
    }
}

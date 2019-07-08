using EquipmentReservation.Framework.Domain;
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
            Assertion.ArgumentNotNull(reservationRepository, nameof(reservationRepository));
            _reservationRepository = reservationRepository;
        }

        public bool IsDupulicateReservation(Reservation reservation)
        {
            Assertion.ArgumentNotNull(reservation, nameof(reservation));
            var reservations = _reservationRepository.FindByEquipmentId(reservation.EquipmentId);
            return reservations.Any(_ => !_.Equals(reservation) && _.IsDupulicated(reservation));
        }
    }
}

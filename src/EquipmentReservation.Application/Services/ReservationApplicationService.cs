using System;
using System.Collections.Generic;
using System.Text;
using EquipmentReservation.Application.Services.Commands;
using EquipmentReservation.Application.Services.Interfaces;
using EquipmentReservation.Domain.Accounts;
using EquipmentReservation.Domain.Equipments;
using EquipmentReservation.Domain.Reservations;

namespace EquipmentReservation.Application.Services
{
    public class ReservationApplicationService : IReservationApplicationService
    {
        private readonly IReservationRepository _reservationRepository;

        public ReservationApplicationService(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository ?? throw new ArgumentNullException(nameof(reservationRepository));
        }

        public void RegisterReservation(RegisterReservationCommand command)
        {
            var reservation = new Reservation(
                new ReservatiionId(),
                new AccountId(command.AccountId),
                new EquipmentId(command.EquipmentId),
                new ReservationDateTime(command.From, command.To));

            var reservationService = new ReservationService(_reservationRepository);

            if (reservationService.IsDupulicateReservation(reservation))
            {
                // Error
            }

            _reservationRepository.Save(reservation);
        }
    }
}

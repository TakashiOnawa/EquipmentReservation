using System;
using System.Collections.Generic;
using System.Text;
using EquipmentReservation.Application.Reservations.Commands;
using EquipmentReservation.Application.Reservations.Data;
using EquipmentReservation.Application.Reservations.Exceptions;
using EquipmentReservation.Domain.Accounts;
using EquipmentReservation.Domain.Equipments;
using EquipmentReservation.Domain.Reservations;

namespace EquipmentReservation.Application.Reservations
{
    public class ReservationAppService : IReservationAppService
    {
        private readonly IReservationRepository _reservationRepository;

        public ReservationAppService(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository ?? throw new ArgumentNullException(nameof(reservationRepository));
        }

        public void RegisterReservation(RegisterReservationCommand command)
        {
            var reservation = new Reservation(
                new ReservatiionId(),
                new AccountId(command.AccountId),
                new EquipmentId(command.EquipmentId),
                new ReservationDateTime(command.StartDateTime, command.EndDateTime),
                new PurposeOfUse(command.PurposeOfUse));

            var service = new ReservationService(_reservationRepository);

            if (service.IsDupulicateReservation(reservation))
            {
                throw new ReservationDupulicationException();
            }

            _reservationRepository.Save(reservation);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using EquipmentReservation.Application.Reservations.Commands;
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

        public void RegisterReservation(RegisterReservationRequest request)
        {
            var reservation = new Reservation(
                new ReservationId(),
                new AccountId(request.AccountId),
                new EquipmentId(request.EquipmentId),
                new ReservationDateTime(request.StartDateTime, request.EndDateTime),
                request.PurposeOfUse);

            var service = new ReservationService(_reservationRepository);
            if (service.IsDupulicateReservation(reservation))
            {
                throw new ReservationDupulicationException();
            }

            _reservationRepository.Save(reservation);
        }

        public void ChangeReservationInfo(ChangeReservationInfoRequest request)
        {
            var reservationId = new ReservationId(request.Id);

            var reservation = _reservationRepository.Find(reservationId);
            if (reservation == null)
            {
                throw new InvalidOperationException(string.Format("予約が登録されていません。 ID:{0}", reservationId.Value));
            }

            reservation.ChangeAccountOfUse(new AccountId(request.AccountId));
            reservation.ChangeEquipment(new EquipmentId(request.EquipmentId));
            reservation.ChangeReservationDateTime(new ReservationDateTime(request.StartDateTime, request.EndDateTime));
            reservation.ChangePurposeOfUse(request.PurposeOfUse);

            var service = new ReservationService(_reservationRepository);
            if (service.IsDupulicateReservation(reservation))
            {
                throw new ReservationDupulicationException();
            }

            _reservationRepository.Save(reservation);
        }
    }
}

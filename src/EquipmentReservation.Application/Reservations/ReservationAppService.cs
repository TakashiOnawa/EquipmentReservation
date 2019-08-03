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
        private readonly IUnitOfWork _unitOfWork;

        public ReservationAppService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public void RegisterReservation(RegisterReservationRequest request)
        {
            try
            {
                var reservation = new Reservation(
                    new ReservationId(),
                    new AccountId(request.AccountId),
                    new EquipmentId(request.EquipmentId),
                    new ReservationDateTime(request.StartDateTime, request.EndDateTime),
                    request.PurposeOfUse);
                var service = new ReservationService(_unitOfWork.ReservationRepository);
                if (service.IsDupulicatedReservation(reservation))
                {
                    throw new ReservationDupulicationException();
                }
                _unitOfWork.ReservationRepository.Save(reservation);
                _unitOfWork.Commit();
            }
            catch
            {
                _unitOfWork.Rollback();
                throw;
            }
        }

        public void ChangeReservationInfo(ChangeReservationInfoRequest request)
        {
            try
            {
                var reservationId = new ReservationId(request.ReservationId);
                var reservation = FindReservationWithValidation(reservationId);

                reservation.ChangeAccountOfUse(new AccountId(request.AccountId));
                reservation.ChangeEquipment(new EquipmentId(request.EquipmentId));
                reservation.ChangeReservationDateTime(new ReservationDateTime(request.StartDateTime, request.EndDateTime));
                reservation.ChangePurposeOfUse(request.PurposeOfUse);
                var service = new ReservationService(_unitOfWork.ReservationRepository);
                if (service.IsDupulicatedReservation(reservation))
                {
                    throw new ReservationDupulicationException();
                }

                _unitOfWork.ReservationRepository.Save(reservation);
                _unitOfWork.Commit();
            }
            catch
            {
                _unitOfWork.Rollback();
                throw;
            }
        }

        public void CancelReservation(CancelReservationRequest request)
        {
            try
            {
                var reservationId = new ReservationId(request.ReservationId);
                var reservation = FindReservationWithValidation(reservationId);

                reservation.Cancel();

                _unitOfWork.ReservationRepository.Save(reservation);
                _unitOfWork.Commit();
            }
            catch
            {
                _unitOfWork.Rollback();
                throw;
            }
        }

        private Reservation FindReservationWithValidation(ReservationId reservationId)
        {
            var reservation = _unitOfWork.ReservationRepository.Find(reservationId);
            if (reservation == null)
            {
                throw new InvalidOperationException(string.Format("予約が登録されていません。 ID:{0}", reservationId.Value));
            }
            return reservation;
        }
    }
}

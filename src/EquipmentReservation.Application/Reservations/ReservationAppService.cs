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
        private static object _saveReservationLockObject = new object();

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

                SaveReservation(reservation);

                _unitOfWork.Commit();
            }
            catch (Exception e)
            {
                _unitOfWork.Rollback();
                throw;
            }
        }

        public void ChangeReservationInfo(ChangeReservationInfoRequest request)
        {
            try
            {
                var reservationId = new ReservationId(request.Id);

                var reservation = _unitOfWork.ReservationRepository.Find(reservationId);
                if (reservation == null)
                {
                    throw new InvalidOperationException(string.Format("予約が登録されていません。 ID:{0}", reservationId.Value));
                }

                reservation.ChangeAccountOfUse(new AccountId(request.AccountId));
                reservation.ChangeEquipment(new EquipmentId(request.EquipmentId));
                reservation.ChangeReservationDateTime(new ReservationDateTime(request.StartDateTime, request.EndDateTime));
                reservation.ChangePurposeOfUse(request.PurposeOfUse);

                SaveReservation(reservation);

                _unitOfWork.Commit();
            }
            catch (Exception e)
            {
                _unitOfWork.Rollback();
                throw;
            }
        }

        private void SaveReservation(Reservation reservation)
        {
            lock (_saveReservationLockObject)
            {
                var service = new ReservationService(_unitOfWork.ReservationRepository);
                if (service.IsDupulicatedReservation(reservation))
                {
                    throw new ReservationDupulicationException();
                }

                _unitOfWork.ReservationRepository.Save(reservation);
            }
        }
    }
}

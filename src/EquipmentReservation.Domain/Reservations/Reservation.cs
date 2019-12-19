using EquipmentReservation.Domain.Accounts;
using EquipmentReservation.Domain.Equipments;
using EquipmentReservation.Framework.Domain;
using System.Collections.Generic;

namespace EquipmentReservation.Domain.Reservations
{
    public class Reservation : IEntity
    {
        public Reservation(
            ReservationId id,
            AccountId accountId,
            EquipmentId equipmentId,
            ReservationDateTime reservationDateTime,
            PurposeOfUse purposeOfUse,
            ReservationStatus reservationStatus)
        {
            Id = id;
            AccountId = accountId;
            EquipmentId = equipmentId;
            ReservationDateTime = reservationDateTime;
            ReservationStatus = ReservationStatus.Reserved;
            PurposeOfUse = purposeOfUse;
            ReservationStatus = reservationStatus;
        }

        private ReservationId _id;
        public ReservationId Id
        {
            get { return _id; }
            private set
            {
                Assertion.ArgumentNotNull(value, nameof(Id));
                _id = value;
            }
        }

        private AccountId _accountId;
        public AccountId AccountId
        {
            get { return _accountId; }
            private set
            {
                Assertion.ArgumentNotNull(value, nameof(AccountId));
                _accountId = value;
            }
        }

        private EquipmentId _equipmentId;
        public EquipmentId EquipmentId
        {
            get { return _equipmentId; }
            private set
            {
                Assertion.ArgumentNotNull(value, nameof(EquipmentId));
                _equipmentId = value;
            }
        }

        private ReservationDateTime _reservationDateTime;
        public ReservationDateTime ReservationDateTime
        {
            get { return _reservationDateTime; }
            private set
            {
                Assertion.ArgumentNotNull(value, nameof(ReservationDateTime));
                _reservationDateTime = value;
            }
        }

        private PurposeOfUse _purposeOfUse;
        public PurposeOfUse PurposeOfUse
        {
            get { return _purposeOfUse; }
            private set
            {
                Assertion.ArgumentNotNull(value, nameof(PurposeOfUse));
                _purposeOfUse = value;
            }
        }

        public ReservationStatus ReservationStatus { get; private set; }

        public void ChangeAccountOfUse(AccountId accountId)
        {
            AccountId = accountId;
        }

        public void ChangeEquipment(EquipmentId equipmentId)
        {
            EquipmentId = equipmentId;
        }

        public void ChangeReservationDateTime(ReservationDateTime reservationDateTime)
        {
            ReservationDateTime = reservationDateTime;
        }

        public void ChangePurposeOfUse(PurposeOfUse purposeOfUse)
        {
            PurposeOfUse = purposeOfUse;
        }

        public bool IsDupulicated(Reservation other)
        {
            Assertion.ArgumentNotNull(other, nameof(other));
            if (!EquipmentId.Equals(other.EquipmentId)) return false;
            if (!ReservationDateTime.IsRangeOverlapping(other.ReservationDateTime)) return false;
            return true;
        }

        public void Cancel()
        {
            ReservationStatus = ReservationStatus.Canceled;
        }

        public override bool Equals(object obj)
        {
            var reservation = obj as Reservation;
            return reservation != null &&
                   EqualityComparer<ReservationId>.Default.Equals(Id, reservation.Id);
        }

        public override int GetHashCode()
        {
            return 2108858624 + EqualityComparer<ReservationId>.Default.GetHashCode(Id);
        }

        public static bool operator ==(Reservation reservation1, Reservation reservation2)
        {
            return EqualityComparer<Reservation>.Default.Equals(reservation1, reservation2);
        }

        public static bool operator !=(Reservation reservation1, Reservation reservation2)
        {
            return !(reservation1 == reservation2);
        }
    }
}

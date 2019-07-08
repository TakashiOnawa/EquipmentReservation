using System;
using System.Collections.Generic;
using System.Text;
using EquipmentReservation.Domain.Accounts;
using EquipmentReservation.Domain.Equipments;
using EquipmentReservation.Framework.Domain;

namespace EquipmentReservation.Domain.Reservations
{
    public class Reservation : IEquatable<Reservation>
    {
        public Reservation(
            ReservationId id,
            AccountId accountId,
            EquipmentId equipmentId,
            ReservationDateTime reservationDateTime)
        {
            Id = id;
            AccountId = accountId;
            EquipmentId = equipmentId;
            ReservationDateTime = reservationDateTime;
        }

        public Reservation(
            ReservationId id,
            AccountId accountId,
            EquipmentId equipmentId,
            ReservationDateTime reservationDateTime,
            string purposeOfUse)
            : this(id, accountId, equipmentId, reservationDateTime)
        {
            PurposeOfUse = purposeOfUse;
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

        private string _purposeOfUse;
        public string PurposeOfUse
        {
            get { return _purposeOfUse; }
            private set
            {
                Assertion.ArgumentRange(value, 64, nameof(PurposeOfUse));
                _purposeOfUse = value;
            }
        }

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

        public void ChangePurposeOfUse(string purposeOfUse)
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

        public override bool Equals(object obj)
        {
            return Equals(obj as Reservation);
        }

        public bool Equals(Reservation other)
        {
            return other != null && Id.Equals(other.Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}

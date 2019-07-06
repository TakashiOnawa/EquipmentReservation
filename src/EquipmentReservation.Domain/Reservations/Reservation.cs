using System;
using System.Collections.Generic;
using System.Text;
using EquipmentReservation.Domain.Accounts;
using EquipmentReservation.Domain.Equipments;

namespace EquipmentReservation.Domain.Reservations
{
    public class Reservation
    {
        public Reservation(
            ReservatiionId id,
            AccountId accountId,
            EquipmentId equipmentId,
            ReservationDateTime reservationDateTime)
        {
            Id = id ?? throw new ArgumentNullException(nameof(id));
            AccountId = accountId ?? throw new ArgumentNullException(nameof(accountId));
            EquipmentId = equipmentId ?? throw new ArgumentNullException(nameof(equipmentId));
            ReservationDateTime = reservationDateTime ?? throw new ArgumentNullException(nameof(reservationDateTime));
        }

        public Reservation(
            ReservatiionId id,
            AccountId accountId,
            EquipmentId equipmentId,
            ReservationDateTime reservationDateTime,
            PurposeOfUse purposeOfUse)
            : this(id, accountId, equipmentId, reservationDateTime)
        {
            PurposeOfUse = purposeOfUse;
        }

        public ReservatiionId Id { get; private set; }
        public AccountId AccountId { get; private set; }
        public EquipmentId EquipmentId { get; private set; }
        public ReservationDateTime ReservationDateTime { get; private set; }
        public PurposeOfUse PurposeOfUse { get; private set; }

        public bool IsDupulicated(Reservation other)
        {
            if (other == null) throw new ArgumentNullException(nameof(other));
            if (!AccountId.Equals(other.AccountId)) return false;
            if (!ReservationDateTime.IsRangeOverlapping(other.ReservationDateTime)) return false;
            return true;
        }
    }
}

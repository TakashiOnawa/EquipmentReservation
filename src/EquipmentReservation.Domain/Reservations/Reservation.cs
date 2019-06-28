using System;
using System.Collections.Generic;
using System.Text;
using EquipmentReservation.Domain.Accounts;
using EquipmentReservation.Domain.Equipments;

namespace EquipmentReservation.Domain.Reservations
{
    public class Reservation
    {
        public Reservation(ReservatiionId id, AccountId accountId, EquipmentId equipmentId, ReservationDateTime reservationDateTime)
        {
            ReservatiionId = id ?? throw new ArgumentNullException(nameof(id));
            AccountId = accountId ?? throw new ArgumentNullException(nameof(accountId));
            EquipmentId = equipmentId ?? throw new ArgumentNullException(nameof(equipmentId));
            ReservationDateTime = reservationDateTime ?? throw new ArgumentNullException(nameof(reservationDateTime));
        }

        public ReservatiionId ReservatiionId { get; private set; }
        public AccountId AccountId { get; private set; }
        public EquipmentId EquipmentId { get; private set; }
        public ReservationDateTime ReservationDateTime { get; private set; }
    }
}

using EquipmentReservation.Application.Accounts.Queries;
using EquipmentReservation.Application.Equipments.Queries;
using EquipmentReservation.Application.Reservations.Queries;
using EquipmentReservation.Domain.Accounts;
using EquipmentReservation.Domain.Equipments;
using EquipmentReservation.Domain.Reservations;
using System;
using System.Collections.Generic;
using System.Text;

namespace EquipmentReservation.Application
{
    public interface IUnitOfWork
    {
        IAccountRepository AccountRepository { get; }
        IEquipmentRepository EquipmentRepository { get; }
        IReservationRepository ReservationRepository { get; }
        
        IAccountDataQuery AccountDataQuery { get; }
        IEquipmentDataQuery EquipmentDataQuery { get; }
        IReservationDataQuery ReservationDataQuery { get; }

        void Commit();
        void Rollback();
    }
}

using EquipmentReservation.Application.Accounts.Queries;
using EquipmentReservation.Application.Equipments.Queries;
using EquipmentReservation.Application.Reservations.Queries;
using EquipmentReservation.Domain.Accounts;
using EquipmentReservation.Domain.Equipments;
using EquipmentReservation.Domain.Reservations;
using System;

namespace EquipmentReservation.Application
{
    public interface IUnitOfWork : IDisposable
    {
        IAccountRepository AccountRepository { get; }
        IEquipmentRepository EquipmentRepository { get; }
        IReservationRepository ReservationRepository { get; }
        
        void Begin();
        void Commit();
        void Rollback();
    }
}

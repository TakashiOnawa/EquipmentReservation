using EquipmentReservation.Application;
using EquipmentReservation.Domain.Accounts;
using EquipmentReservation.Domain.Equipments;
using EquipmentReservation.Domain.Reservations;
using EquipmentReservation.Infrastructure.Database;
using EquipmentReservation.Infrastructure.Repositories;
using System;

namespace EquipmentReservation.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyDbContext _dbContext;

        public UnitOfWork(MyDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        private IAccountRepository _accountRepository;
        public IAccountRepository AccountRepository
        {
            get
            {
                if (_accountRepository == null) _accountRepository = new AccountRepository(_dbContext);
                return _accountRepository;
            }
        }

        private IEquipmentRepository _equipmentRepository;
        public IEquipmentRepository EquipmentRepository
        {
            get
            {
                if (_equipmentRepository == null) _equipmentRepository = new EquipmentRepository(_dbContext);
                return _equipmentRepository;
            }
        }

        private IReservationRepository _reservationRepository;
        public IReservationRepository ReservationRepository
        {
            get
            {
                if (_reservationRepository == null) _reservationRepository = new ReservationRepository(_dbContext);
                return _reservationRepository;
            }
        }

        public void Begin()
        {
            _dbContext.Database.BeginTransaction();
        }

        public void Commit()
        {
            _dbContext.Database.CommitTransaction();
        }

        public void Rollback()
        {
            _dbContext.Database.RollbackTransaction();
        }

        private bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                _dbContext.Dispose();
            }

            disposed = true;
        }
    }
}

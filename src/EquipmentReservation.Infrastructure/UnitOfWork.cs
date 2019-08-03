using EquipmentReservation.Application;
using EquipmentReservation.Application.Accounts.Queries;
using EquipmentReservation.Application.Equipments.Queries;
using EquipmentReservation.Application.Reservations.Queries;
using EquipmentReservation.Domain.Accounts;
using EquipmentReservation.Domain.Equipments;
using EquipmentReservation.Domain.Reservations;
using EquipmentReservation.Infrastructure.Application.Repositories;
using EquipmentReservation.Infrastructure.Database;
using EquipmentReservation.Infrastructure.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

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

        private IAccountDataQuery _accountDataQuery;
        public IAccountDataQuery AccountDataQuery
        {
            get
            {
                if (_accountDataQuery == null) _accountDataQuery = new AccountDataQuery(_dbContext);
                return _accountDataQuery;
            }
        }

        private IEquipmentDataQuery _equipmentDataQuery;
        public IEquipmentDataQuery EquipmentDataQuery
        {
            get
            {
                if (_equipmentDataQuery == null) _equipmentDataQuery = new EquipmentDataQuery(_dbContext);
                return _equipmentDataQuery;
            }
        }

        private IReservationDataQuery _reservationDataQuery;
        public IReservationDataQuery ReservationDataQuery
        {
            get
            {
                if (_reservationDataQuery == null) _reservationDataQuery = new ReservationDataQuery(_dbContext);
                return _reservationDataQuery;
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
    }
}

using EquipmentReservation.Application;
using EquipmentReservation.Application.Accounts.Queries;
using EquipmentReservation.Application.Equipments.Queries;
using EquipmentReservation.Application.Reservations.Queries;
using EquipmentReservation.Infrastructure.Database;
using EquipmentReservation.Infrastructure.Queries;
using System;

namespace EquipmentReservation.Infrastructure
{
    public class QueryFactory : IQueryFactory
    {
        private readonly MyDbContext _dbContext;

        public QueryFactory(MyDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public IAccountDataQuery AccountDataQuery => new AccountDataQuery(_dbContext);
        public IEquipmentDataQuery EquipmentDataQuery => new EquipmentDataQuery(_dbContext);
        public IReservationDataQuery ReservationDataQuery => new ReservationDataQuery(_dbContext);
    }
}

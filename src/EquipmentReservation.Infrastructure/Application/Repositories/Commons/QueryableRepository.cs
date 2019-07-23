using Dapper;
using EquipmentReservation.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EquipmentReservation.Infrastructure.Application.Repositories.Commons
{
    public abstract class QueryableRepository
    {
        protected readonly MyDbContext _dbContext;

        public QueryableRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        protected T QueryObject<T>(string query, object parameter)
        {
            return Query<T>(query, parameter).FirstOrDefault();
        }

        protected IEnumerable<T> QueryObjects<T>(string query, object parameter = null)
        {
            return Query<T>(query, parameter).ToList();
        }

        private IEnumerable<T> Query<T>(string query, object parameter = null)
        {
            return _dbContext.Database.GetDbConnection().Query<T>(query, parameter, transaction: _dbContext.Database.CurrentTransaction.GetDbTransaction());
        }
    }
}

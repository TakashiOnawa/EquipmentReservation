using System;
using System.Collections.Generic;
using System.Text;
using EquipmentReservation.Application;

namespace EquipmentReservation.Infrastructure.Application.Repositories
{
    public class QueryableRepository : IQueryableRepository
    {
        public T QueryObject<T>(string query, params object[] arguments)
        {
            return default(T);
        }

        public IEnumerable<T> QueryObjects<T>(string query, params object[] arguments)
        {
            return new List<T>();
        }
    }
}

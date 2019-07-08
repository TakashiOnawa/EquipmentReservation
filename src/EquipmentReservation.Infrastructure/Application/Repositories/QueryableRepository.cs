using System;
using System.Collections.Generic;
using System.Text;
using EquipmentReservation.Application;

namespace EquipmentReservation.Infrastructure.Application.Repositories
{
    class QueryableRepository
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolarisDesk.DataAccessLayer
{
    public interface IPolarisDeskContext
    {
        IQueryable<T> GetData<T>(bool trackingChanges = false) where T : class;

        void Insert<T>(T entity) where T : class;

        Task SaveAsync();

        Task ExecuteTransactionAsync(Func<Task> action);
    }
}

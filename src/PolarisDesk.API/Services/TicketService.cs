
using PolarisDesk.API.Data;
using PolarisDesk.API.Interface;
using PolarisDesk.DataAccessLayer;
using System.Threading.Tasks;

namespace PolarisDesk.API.Services
{

    public class TicketService<T, TKey> : ICrudService<T, TKey> where T: class
    {
        private readonly PolarisDeskContext polarisDeskContext;

        public TicketService(PolarisDeskContext polarisDeskContext)
        {
            this.polarisDeskContext = polarisDeskContext;
        }

        public Task Create(T item)
        {
            this.polarisDeskContext.Set<T>().Add(item);
            return this.polarisDeskContext.SaveChangesAsync();
        }

        public Task Delete(TKey id)
        {
            throw new System.NotImplementedException();
        }

        public Task<T> Get(TKey id)
        {
            throw new System.NotImplementedException();
        }

        public Task<T[]> GetList()
        {
            throw new System.NotImplementedException();
        }

        public Task Update(T item)
        {
            throw new System.NotImplementedException();
        }
    }
}

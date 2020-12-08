using PolarisDesk.API.Interface;
using System.Threading.Tasks;

namespace PolarisDesk.API.Services
{
    public class TicketStatusService<T, TKey> : ICrudService<T, TKey> where T : class
    {
        public Task Create(T item)
        {
            throw new System.NotImplementedException();
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
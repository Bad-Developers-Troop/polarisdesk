
using PolarisDesk.API.Interface;
using System.Threading.Tasks;

namespace PolarisDesk.API.Services
{
    
    public class TicketService<T, K> : ICrudService<T, K>
    {
        public Task Create(K item)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<K> Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<T[]> GetList()
        {
            throw new System.NotImplementedException();
        }

        public Task Update(K item)
        {
            throw new System.NotImplementedException();
        }
    }
}

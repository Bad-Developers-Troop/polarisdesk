using PolarisDesk.API.Data;
using PolarisDesk.API.Interface;
using System.Linq;
using System.Threading.Tasks;

namespace PolarisDesk.API.Services
{
    public class CustomerService<T, TKey> : ICrudService<T, TKey> where T : class
    {
        private readonly PolarisDeskContext polarisDeskContext;

        public CustomerService(PolarisDeskContext polarisDeskContext)
        {
            this.polarisDeskContext = polarisDeskContext;
        }

        public Task Create(T item)
        {
            this.polarisDeskContext.Set<T>().Add(item);
            return this.polarisDeskContext.SaveChangesAsync();
        }

        public async Task Delete(TKey id)
        {
            var entity = await this.polarisDeskContext.Set<T>().FindAsync(id);

            this.polarisDeskContext.Set<T>().Remove(entity);
            await this.polarisDeskContext.SaveChangesAsync();
        }

        public Task<T> Get(TKey id)
        {
            return this.polarisDeskContext.Set<T>().FindAsync(id).AsTask();
        }

        public async Task<T[]> GetList()
        {
            return this.polarisDeskContext.Set<T>().AsEnumerable().ToArray();
        }

        public Task Update(T item)
        {
            this.polarisDeskContext.Set<T>().Update(item);
            return this.polarisDeskContext.SaveChangesAsync();
        }
    }
}
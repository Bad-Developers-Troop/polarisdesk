using Bogus;
using PolarisDesk.API.Interface;
using PolarisDesk.DataAccessLayer;
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

        public async Task Create(T item)
        {
            var strategy = polarisDeskContext.Database.CreateExecutionStrategy();
            await strategy.ExecuteAsync(async () => 
            {
                using var transaction = await polarisDeskContext.Database.BeginTransactionAsync();
                //... 
                await transaction.CommitAsync();
            });

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
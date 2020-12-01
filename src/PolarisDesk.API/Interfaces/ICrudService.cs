using System.Threading.Tasks;

namespace PolarisDesk.API.Interface
{
    public interface ICrudService<T,K>
    {
        Task Create(K item);
        Task Update(K item);
        Task Delete(int id);
        Task<K> Get(int id);
        Task<T[]> GetList();
     }


}

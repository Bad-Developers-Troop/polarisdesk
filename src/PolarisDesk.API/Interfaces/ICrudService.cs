using System.Threading.Tasks;

namespace PolarisDesk.API.Interface
{
    public interface ICrudService<T,Tkey> where T:class
    {
        Task Create(T item);
        Task Update(T item);
        Task Delete(Tkey id);
        Task<T> Get(Tkey id);
        Task<T[]> GetList();
     }


}

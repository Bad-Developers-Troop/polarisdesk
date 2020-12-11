using PolarisDesk.API.Interface;
using PolarisDesk.Models;
using System;
using System.Threading.Tasks;

namespace PolarisDesk.API.Services
{
	public class CustomerService : ICrudService<Customer, Guid>
	{
		public Task Create(Customer item)
		{
			throw new NotImplementedException();
		}

		public Task Delete(Guid id)
		{
			throw new NotImplementedException();
		}

		public Task<Customer> Get(Guid id)
		{
			throw new NotImplementedException();
		}

		public Task<Customer[]> GetList()
		{
			throw new NotImplementedException();
		}

		public Task Update(Customer item)
		{
			throw new NotImplementedException();
		}
	}
}
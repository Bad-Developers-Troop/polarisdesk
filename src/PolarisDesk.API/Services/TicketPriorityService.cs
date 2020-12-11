using PolarisDesk.API.Interface;
using PolarisDesk.Models;
using System;
using System.Threading.Tasks;

namespace PolarisDesk.API.Services
{
	public class TicketPriorityService : ICrudService<TicketPriority, Guid>
	{
		public Task Create(TicketPriority item)
		{
			throw new NotImplementedException();
		}

		public Task Delete(Guid id)
		{
			throw new NotImplementedException();
		}

		public Task<TicketPriority> Get(Guid id)
		{
			throw new NotImplementedException();
		}

		public Task<TicketPriority[]> GetList()
		{
			throw new NotImplementedException();
		}

		public Task Update(TicketPriority item)
		{
			throw new NotImplementedException();
		}
	}
}
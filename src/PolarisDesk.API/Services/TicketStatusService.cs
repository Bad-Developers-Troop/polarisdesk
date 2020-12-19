
using PolarisDesk.Models;
using PolarisDesk.Shared.Interface;
using System;
using System.Threading.Tasks;

namespace PolarisDesk.API.Services
{
	public class TicketStatusService : ICrudService<TicketStatus, Guid>
	{
		public Task Create(TicketStatus item)
		{
			throw new NotImplementedException();
		}

		public Task Delete(Guid id)
		{
			throw new NotImplementedException();
		}

		public Task<TicketStatus> Get(Guid id)
		{
			throw new NotImplementedException();
		}

		public Task<TicketStatus[]> GetList()
		{
			throw new NotImplementedException();
		}

		public Task Update(TicketStatus item)
		{
			throw new NotImplementedException();
		}
	}
}
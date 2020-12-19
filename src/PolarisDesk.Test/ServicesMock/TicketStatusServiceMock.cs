using Bogus;
using PolarisDesk.DAL;
using PolarisDesk.Models;
using PolarisDesk.Shared.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolarisDesk.Test.Services
{
	public class TicketStatusServiceMock : ICrudService<TicketStatus, Guid>
	{
		private readonly PolarisDeskContext context;

		public TicketStatusServiceMock(PolarisDeskContext context)
		{
			this.context = context;
		}
		public Task Create(TicketStatus item)
		{
			context.TicketStatus.Add(item);
			return Task.CompletedTask;
		}

		public async Task Delete(Guid id)
		{
			var ticket = await Get(id);
			if (ticket != null)
			{
				ticket.Enabled = false;
				ticket.Deleted = DateTime.Now;
			}
			await context.SaveChangesAsync();
		}

		public Task<TicketStatus> Get(Guid id)
		{
			return Task.FromResult(context.TicketStatus.Where(x => x.ID == id).SingleOrDefault());
		}

		public Task<TicketStatus[]> GetList()
		{
			return Task.FromResult(context.TicketStatus.Where(x => x.Enabled).ToArray());
		}

		public async Task Update(TicketStatus item)
		{
			var ticket = await Get(item.ID);
			if (ticket != null)
			{
				ticket.Name = item.Name;
				ticket.Updated = DateTime.Now;
				ticket.Enabled = item.Enabled;
				if (ticket.Enabled)
					ticket.Deleted = DateTime.MinValue;
				else
					ticket.Deleted = DateTime.Now;
			}
			await context.SaveChangesAsync();
		}
	}
}
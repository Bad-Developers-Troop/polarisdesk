
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
	public class TicketServiceMock : ICrudService<Ticket, Guid>
	{
		private readonly PolarisDeskContext context;

		public TicketServiceMock(PolarisDeskContext context)
		{
			this.context = context;
		}
	
		public Task Create(Ticket item)
		{
			context.Tickets.Add(item);
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

		public Task<Ticket> Get(Guid id)
		{
			return Task.FromResult(context.Tickets.Where(x => x.ID == id).SingleOrDefault());
		}

		public Task<Ticket[]> GetList()
		{
			return Task.FromResult(context.Tickets.Where(x => x.Enabled).ToArray());
		}

		public async Task Update(Ticket item)
		{
			var ticket = await Get(item.ID);
			if (ticket != null)
			{
				ticket.Title = item.Title;
				ticket.Code = item.Code;
				ticket.Description = item.Description;
				ticket.Enabled = item.Enabled;
				ticket.Updated = DateTime.Now;
				if (ticket.Enabled)
					ticket.Deleted = DateTime.MinValue;
				else
					ticket.Deleted = DateTime.Now;
			}
			await context.SaveChangesAsync();
		}
	}
}

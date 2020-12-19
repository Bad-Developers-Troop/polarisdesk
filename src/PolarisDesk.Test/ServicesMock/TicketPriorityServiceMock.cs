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
	public class TicketPriorityServiceMock : ICrudService<TicketPriority, Guid>
	{
		private readonly PolarisDeskContext context;

		public TicketPriorityServiceMock(PolarisDeskContext context)
		{
			this.context = context;
		}

		public Task Create(TicketPriority item)
		{
			context.TicketPriorities.AddAsync(item);
			return context.SaveChangesAsync();
		}

		public async Task Delete(Guid id)
		{
			var priority = await Get(id);
			if (priority != null)
			{
				priority.Enabled = false;
				priority.Deleted = DateTime.Now;
			}
			await context.SaveChangesAsync();
		}

		public Task<TicketPriority> Get(Guid id)
		{
			return Task.FromResult(context.TicketPriorities.Where(x => x.ID == id).SingleOrDefault());
		}

		public Task<TicketPriority[]> GetList()
		{
			return Task.FromResult(context.TicketPriorities.Where(x => x.Enabled).ToArray());
		}

		public async Task Update(TicketPriority item)
		{
			var priority = await Get(item.ID);
			{
				priority.Name = item.Name;
				priority.Value = item.Value;
				priority.Enabled = item.Enabled;
				priority.Updated = DateTime.Now;
				if (priority.Enabled)
					priority.Deleted = DateTime.MinValue;
				else
					priority.Deleted = DateTime.Now;
			}
			await context.SaveChangesAsync();
		}
	}
}
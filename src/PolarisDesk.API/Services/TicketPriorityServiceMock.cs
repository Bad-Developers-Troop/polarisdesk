using Bogus;
using PolarisDesk.API.Interface;
using PolarisDesk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolarisDesk.API.Services
{
	public class TicketPriorityServiceMock : ICrudService<TicketPriority, Guid>
	{
		static List<TicketPriority> ticketPriority = null;
		static TicketPriorityServiceMock()
		{
			var testPriority = new Faker<TicketPriority>()

			.RuleFor(o => o.ID, f => f.Random.Guid())
			.RuleFor(o => o.Value, f => f.Random.Int(0, 1000))
			.RuleFor(o => o.Name, f => f.Lorem.Sentences(1))
			.RuleFor(o => o.Created, f => f.Date.Recent(5))
			.RuleFor(o => o.Updated, f => f.Date.Recent(2));

			var priority = testPriority.Generate(500);
			ticketPriority = priority;

		}

		public Task Create(TicketPriority item)
		{
			ticketPriority.Add(item);
			return Task.CompletedTask;
		}

		public async Task Delete(Guid id)
		{
			var priority = await Get(id);
			if (priority is not null)
			{
				priority.Enabled = false;
				priority.Deleted = DateTime.Now;
			}
		}

		public Task<TicketPriority> Get(Guid id)
		{
			return Task.FromResult(ticketPriority.Where(x => x.ID == id).SingleOrDefault());
		}

		public Task<TicketPriority[]> GetList()
		{
			return Task.FromResult(ticketPriority.Where(x => x.Enabled).ToArray());
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

		}
	}
}
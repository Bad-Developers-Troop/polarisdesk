using Bogus;
using PolarisDesk.API.Interface;
using PolarisDesk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolarisDesk.API.Services
{
	public class TicketStatusServiceMock : ICrudService<TicketStatus, Guid>
	{
		static List<TicketStatus> ticketStatus;
		static  TicketStatusServiceMock()
		{
			var testStatus = new Faker<TicketStatus>()

		.RuleFor(o => o.ID, f => f.Random.Guid())
		.RuleFor(o => o.Name, f => f.Lorem.Sentences(1))
		.RuleFor(o => o.Created, f => f.Date.Recent(5))
		.RuleFor(o => o.Updated, f => f.Date.Recent(2));

			ticketStatus =  testStatus.Generate(500);
		}
		public Task Create(TicketStatus item)
		{
			ticketStatus.Add(item);
			return Task.CompletedTask;
		}

		public async Task Delete(Guid id)
		{
			var ticket = await Get(id);
			if(ticket is not null)
			{
				ticketStatus.Remove(ticket);
			}
		}

		public Task<TicketStatus> Get(Guid id)
		{
			return Task.FromResult(ticketStatus.Where(x => x.ID == id).SingleOrDefault());
		}

		public Task<TicketStatus[]> GetList()
		{
			return Task.FromResult(ticketStatus.ToArray());
		}

		public async Task Update(TicketStatus item)
		{
			var ticket = await Get(item.ID);
			ticket.Name = item.Name;
			ticket.Updated = DateTime.Now;
		}
	}
}
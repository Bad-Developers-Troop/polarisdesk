
using Bogus;

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
		static List<Ticket> tickets;
		public TicketServiceMock()
		{
			var testTickets = new Faker<Ticket>()

			.RuleFor(o => o.ID, f => f.Random.Guid())
			.RuleFor(o => o.Code, f => f.Random.Int(0, 1000).ToString())
			.RuleFor(o => o.Title, f => f.Lorem.Sentences(1))
			.RuleFor(o => o.Description, f => f.Lorem.Sentences(3))
			.RuleFor(o => o.Created, f => f.Date.Recent(5))
			.RuleFor(o => o.Updated, f => f.Date.Recent(2));

			tickets = testTickets.Generate(500);
		}
		public Task Create(Ticket item)
		{
			tickets.Add(item);
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
		}

		public Task<Ticket> Get(Guid id)
		{
			return Task.FromResult(tickets.Where(x => x.ID == id).SingleOrDefault());
		}

		public Task<Ticket[]> GetList()
		{
			return Task.FromResult(tickets.Where(x => x.Enabled).ToArray());
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
		}
	}
}

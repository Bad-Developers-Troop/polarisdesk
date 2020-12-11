
using Bogus;
using PolarisDesk.API.Interface;
using PolarisDesk.Models;
using System;
using System.Threading.Tasks;

namespace PolarisDesk.API.Services
{
    public class TicketServiceMock: ICrudService<Ticket, Guid>
    {
        public Task Create(Ticket item)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(Guid id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Ticket> Get(Guid id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Ticket[]> GetList()
        {
            var testTickets = new Faker<Ticket>()

            .RuleFor(o => o.ID, f => f.Random.Guid())
            .RuleFor(o => o.Code, f => f.Random.Int(0, 1000).ToString())
            .RuleFor(o => o.Title, f => f.Lorem.Sentences(1))
            .RuleFor(o => o.Description, f => f.Lorem.Sentences(3))
            .RuleFor(o => o.Created, f => f.Date.Recent(5))
            .RuleFor(o => o.Updated, f => f.Date.Recent(2));

            var tickets = testTickets.Generate(500);

            return Task.FromResult(tickets.ToArray());
        }

        public Task Update(Ticket item)
        {
            throw new System.NotImplementedException();
        }
    }
}

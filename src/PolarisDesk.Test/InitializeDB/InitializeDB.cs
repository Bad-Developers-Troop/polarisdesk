using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PolarisDesk.DAL;
using PolarisDesk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PolarisDesk.Test.InitializeDB
{
	public static class InitializeDB
	{
		public static void Initialize(IServiceProvider serviceProvider)
		{
			using (var context = new PolarisDeskContext(
				serviceProvider.GetRequiredService<DbContextOptions<PolarisDeskContext>>()))
			{
				// Look for any board games already in database.
				if (context.Tickets.Any())
				{
					return;   // Database has been seeded
				}
				var testCustomers = new Faker<Customer>()

				.RuleFor(o => o.ID, f => f.Random.Guid())
				.RuleFor(o => o.Name, f => f.Company.CompanyName(1))
				.RuleFor(o => o.Description, f => f.Company.CompanySuffix())
				.RuleFor(o => o.Created, f => f.Date.Recent(5))
				.RuleFor(o => o.Updated, f => f.Date.Recent(2))
				.RuleFor(o => o.Address, f => f.Address.FullAddress())
				.RuleFor(o => o.Zip, f => f.Address.ZipCode())
				.RuleFor(o => o.City, f => f.Address.City())
				.RuleFor(o=> o.Enabled,f=>true)
				.RuleFor(o => o.Note, f => f.Lorem.Sentences(1));
				

				context.Customers.AddRange(testCustomers.Generate(200));


				var testPriority = new Faker<TicketPriority>()

				.RuleFor(o => o.ID, f => f.Random.Guid())
				.RuleFor(o => o.Value, f => f.Random.Int(0, 1000))
				.RuleFor(o => o.Name, f => f.Lorem.Sentences(1))
				.RuleFor(o => o.Created, f => f.Date.Recent(5))
				.RuleFor(o => o.Updated, f => f.Date.Recent(2));

				context.TicketPriorities.AddRange(testPriority.Generate(500));


				var testTickets = new Faker<Ticket>()

					.RuleFor(o => o.ID, f => f.Random.Guid())
					.RuleFor(o => o.Code, f => f.Random.Int(0, 1000).ToString())
					.RuleFor(o => o.Title, f => f.Lorem.Sentences(1))
					.RuleFor(o => o.Description, f => f.Lorem.Sentences(3))
					.RuleFor(o => o.Created, f => f.Date.Recent(5))
					.RuleFor(o => o.Updated, f => f.Date.Recent(2));

				context.Tickets.AddRange(testTickets.Generate(500));



				var testStatus = new Faker<TicketStatus>()

					.RuleFor(o => o.ID, f => f.Random.Guid())
					.RuleFor(o => o.Name, f => f.Lorem.Sentences(1))
					.RuleFor(o => o.Created, f => f.Date.Recent(5))
					.RuleFor(o => o.Updated, f => f.Date.Recent(2));

				context.TicketStatus.AddRange(testStatus.Generate(500));

				context.SaveChanges();

			}
		}
	}
}

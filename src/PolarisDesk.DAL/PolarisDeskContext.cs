using Microsoft.EntityFrameworkCore;
using PolarisDesk.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PolarisDesk.DAL
{
	public class PolarisDeskContext : DbContext
	{
		public PolarisDeskContext(DbContextOptions<PolarisDeskContext> options) : base(options)
		{
		}
		public DbSet<Customer> Customers { get; set; }
		public DbSet<Department> Departments { get; set; }
		public DbSet<Ticket> Tickets { get; set; }
		public DbSet<TicketHistory> TicketHistories { get; set; }
		public DbSet<TicketPriority> TicketPriorities { get; set; }
		public DbSet<TicketStatus> TicketStatus { get; set; }

	}
}

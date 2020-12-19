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

	public class CustomerServiceMock : ICrudService<Customer, Guid>
	{
		private readonly PolarisDeskContext context;

		public CustomerServiceMock(PolarisDeskContext context)
		{
			this.context = context;
		}
		public Task Create(Customer item)
		{
			context.Customers.Add(item);
			return context.SaveChangesAsync();
		}

		public async Task Delete(Guid id)
		{
			var customer = await Get(id);
			if (customer != null)
			{
				customer.Enabled = false;
				customer.Deleted = DateTime.Now;
			}
			await context.SaveChangesAsync();
		}

		public Task<Customer> Get(Guid id)
		{
			return Task.FromResult(context.Customers.Where(x => x.ID == id).FirstOrDefault());
		}
		public Task<Customer[]> GetList()
		{
			var result = context.Customers.Where(x => x.Enabled);
			return Task.FromResult(result.ToArray());
		}

		public async Task Update(Customer item)
		{
			var customer = await Get(item.ID);
			if (customer != null)
			{
				customer.Name = item.Name;
				customer.Note = item.Note;
				customer.Zip = item.Zip;
				customer.Address = item.Address;
				customer.City = item.City;
				customer.Description = item.Description;
				customer.Description2 = item.Description2;
				customer.Enabled = item.Enabled;
				customer.Updated = DateTime.Now;
				if (customer.Enabled)
					customer.Deleted = DateTime.MinValue;
				else
					customer.Deleted = DateTime.Now;

			}
			await context.SaveChangesAsync();
		}
	}
}

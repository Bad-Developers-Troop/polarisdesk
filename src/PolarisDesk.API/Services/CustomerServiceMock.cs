using Bogus;
using PolarisDesk.API.Interface;
using PolarisDesk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolarisDesk.API.Services
{

    public class CustomerServiceMock : ICrudService<Customer, Guid>
    {
        static List<Customer> customers;
 
		static CustomerServiceMock()
		{
            var testCustomers = new Faker<Customer>()

                .RuleFor(o => o.ID, f => f.Random.Guid())
                .RuleFor(o => o.Description, f => f.Company.CompanyName(1))
                .RuleFor(o => o.Description2, f => f.Company.CompanySuffix())
                .RuleFor(o => o.Created, f => f.Date.Recent(5))
                .RuleFor(o => o.Updated, f => f.Date.Recent(2))
                .RuleFor(o => o.Address, f => f.Address.FullAddress())
                .RuleFor(o => o.Zip, f => f.Address.ZipCode())
                .RuleFor(o => o.City, f => f.Address.City())
                .RuleFor(o => o.Note, f => f.Lorem.Sentences(1));

            customers = testCustomers.Generate(200);

        }
        public Task Create(Customer item)
        {
            customers.Add(item);
            return Task.CompletedTask;
        }

        public async Task Delete(Guid id)
        {
            var customer = await Get(id);
            if (customer is not null)
            {
                customer.Enabled = false;
                customer.Deleted = DateTime.Now;
            }
        }

        public Task<Customer> Get(Guid id)
        {
            return Task.FromResult(customers.Where(x => x.ID == id).SingleOrDefault());
        }

        public Task<Customer[]> GetList()
        {           
            return Task.FromResult(customers.Where(x=> x.Enabled).ToArray());
        }

        public async Task Update(Customer item)
        {
            var customer = await Get(item.ID);
            if (customer is not null)
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
        }
    }
}

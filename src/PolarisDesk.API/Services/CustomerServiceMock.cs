using Bogus;
using PolarisDesk.API.Interface;
using PolarisDesk.Models;
using System;
using System.Threading.Tasks;

namespace PolarisDesk.API.Services
{

    public class CustomerServiceMock : ICrudService<Customer, Guid>
    {
        public Task Create(Customer item)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(Guid id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Customer> Get(Guid id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Customer[]> GetList()
        {
            var testCustomers = new Faker<Customer>()

                .RuleFor(o => o.ID, f => f.Random.Guid())
                .RuleFor(o => o.Name, f => f.Company.CompanyName(1))
                .RuleFor(o => o.Description, f => f.Company.CompanySuffix())
                .RuleFor(o => o.Created, f => f.Date.Recent(5))
                .RuleFor(o => o.Updated, f => f.Date.Recent(2))
                .RuleFor(o => o.Address, f => f.Address.FullAddress())
                .RuleFor(o => o.Zip, f => f.Address.ZipCode())
                .RuleFor(o => o.City, f => f.Address.City())
                .RuleFor(o => o.Note, f => f.Lorem.Sentences(1));

            var customers = testCustomers.Generate(200);

            return Task.FromResult(customers.ToArray());
        }

        public Task Update(Customer item)
        {
            throw new System.NotImplementedException();
        }
    }
}

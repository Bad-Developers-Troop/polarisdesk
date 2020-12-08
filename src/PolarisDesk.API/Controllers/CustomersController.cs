using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using PolarisDesk.API.Interface;
using PolarisDesk.Models;

namespace PolarisDesk.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICrudService<Customer, Guid> _customerService;

        public CustomersController(ICrudService<Customer, Guid> customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            //_customerService.GetList();

            return new List<Customer>()
            {
                new Customer() { Name= "Customer01", Description="Description01", Description2="Description2-01",Address="Address01", City="City01", Zip="Zip01",Note="Note01",Created = DateTime.Now },
                new Customer() { Name= "Customer02", Description="Description02", Description2="Description2-02",Address="Address02", City="City02", Zip="Zip02",Note="Note02",Created = DateTime.Now },
                new Customer() { Name= "Customer03", Description="Description03", Description2="Description2-03",Address="Address03", City="City03", Zip="Zip03",Note="Note03",Created = DateTime.Now },
                new Customer() { Name= "Customer04", Description="Description04", Description2="Description2-04",Address="Address04", City="City04", Zip="Zip04",Note="Note04",Created = DateTime.Now }
            };
        }


        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public Customer Get(Guid id)
        {
            return new Customer() { Name = "Customer001", Description = "Description01", Description2 = "Description2-01", Address = "Address01", City = "City01", Zip = "Zip01", Note = "Note01"};
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] Customer value)
        {

        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] Customer value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
        }

    }
}

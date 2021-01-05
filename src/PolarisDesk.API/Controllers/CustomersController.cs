using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
        public async Task<IEnumerable<Customer>> Get()
        {
            return await _customerService.GetList();
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

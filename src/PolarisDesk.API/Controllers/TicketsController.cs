using Microsoft.AspNetCore.Mvc;
using PolarisDesk.API.Interface;
using PolarisDesk.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PolarisDesk.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly ICrudService<Ticket, Guid> _ticketService;

        public TicketsController(ICrudService<Ticket, Guid> ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpGet]
        public async Task<IEnumerable<Ticket>> Get()
        {
            return await _ticketService.GetList();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public Ticket Get(Guid id)
        {
            return new Ticket() { Code = "Test001" };
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] Ticket value)
        {

        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] Ticket value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
        }

    }
}

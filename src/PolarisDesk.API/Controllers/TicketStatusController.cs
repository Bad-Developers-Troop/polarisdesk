using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

using PolarisDesk.Models;
using System.Threading.Tasks;
using PolarisDesk.Shared.Interface;

namespace PolarisDesk.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketStatusController : ControllerBase
    {
        private readonly ICrudService<TicketStatus, Guid> _ticketStatusService;

        public TicketStatusController(ICrudService<TicketStatus, Guid> ticketStatusService)
        {
            _ticketStatusService = ticketStatusService;
        }

        [HttpGet]
        public async Task<IEnumerable<TicketStatus>> Get()
        {

            return await _ticketStatusService.GetList();

       
        }


        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public TicketStatus Get(Guid id)
        {
            return new TicketStatus() { Name = "Open"};
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] TicketStatus value)
        {

        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] TicketStatus value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
        }

    }
}

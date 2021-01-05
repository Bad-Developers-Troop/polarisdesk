using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using PolarisDesk.API.Interface;
using PolarisDesk.Models;

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
        public IEnumerable<TicketStatus> Get()
        {
            //_ticketStatusService.GetList();

            return new List<TicketStatus>()
            {
                new TicketStatus() {Name= "Open",Created = DateTime.Now, ID = Guid.NewGuid()},
                new TicketStatus() {Name= "Close",Created = DateTime.Now, ID = Guid.NewGuid() },
                new TicketStatus() {Name= "Pending",Created = DateTime.Now, ID = Guid.NewGuid()},
            };
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

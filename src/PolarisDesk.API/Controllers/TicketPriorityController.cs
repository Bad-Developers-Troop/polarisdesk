using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using PolarisDesk.API.Interface;
using PolarisDesk.Models;

namespace PolarisDesk.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketPriorityController : ControllerBase
    {
        private readonly ICrudService<TicketPriority, Guid> _ticketPriorityService;

        public TicketPriorityController(ICrudService<TicketPriority, Guid> ticketPriorityService)
        {
            _ticketPriorityService = ticketPriorityService;
        }

        [HttpGet]
        public IEnumerable<TicketPriority> Get()
        {
            //_ticketStatusService.GetList();

            return new List<TicketPriority>()
            {
                new TicketPriority() { Name= "High",Created = DateTime.Now, ID = Guid.NewGuid()},
                new TicketPriority() { Name="Medium",Created = DateTime.Now, ID = Guid.NewGuid()},
                new TicketPriority() { Name= "Low",Created = DateTime.Now, ID = Guid.NewGuid()},
            };
        }


        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public TicketPriority Get(Guid id)
        {
            return new TicketPriority() { Name = "Open" };
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] TicketPriority value)
        {

        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] TicketPriority value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
        }

    }
}

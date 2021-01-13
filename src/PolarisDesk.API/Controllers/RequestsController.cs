using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PolarisDesk.API.Data;
using PolarisDesk.Models.Requests;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PolarisDesk.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestsController : ControllerBase
    {
        private readonly PolarisDeskContext _context;

        public RequestsController(PolarisDeskContext context)
        {
            _context = context;
        }

       
        // POST: api/Requests
        [HttpPost]
        public async Task<ActionResult<Request>> PostRequest(NewRequest newRequest)
        {
            var requestType = await _context.RequestTypes.Where(a => a.Id == newRequest.RequestTypeId).FirstOrDefaultAsync();
            if (requestType == null)
                return NotFound();

            var startDate = newRequest.StartTime.Date;
            var endDate = newRequest.EndTime.Date;
            var requests = new List<Request>();
            while (startDate <= endDate)
            {
                var request = new Request
                {
                    RequestTypeId = newRequest.UserId,
                    IsApproved = false,
                    UserId = newRequest.UserId,
                    ApprovedDateTime = new DateTime(1900, 1, 1),
                    RejectDateTime = new DateTime(1900, 1, 1),
                    RequestStarDateTime = newRequest.StartTime,
                    RequestEndDateTime = newRequest.EndTime,
                    RequestDate = startDate,
                    InternalId = $"{DateTime.Now.Year}{DateTime.Now.Month}{DateTime.Now.Day}{DateTime.Now.Ticks}"
                };
                requests.Add(request);
                startDate = startDate.AddDays(1);
            }

            await _context.Request.AddRangeAsync(requests);
            await _context.SaveChangesAsync();
            
            return Ok();

        }


        private bool RequestExists(Guid id)
        {
            return _context.Request.Any(e => e.Id == id);
        }
    }
}

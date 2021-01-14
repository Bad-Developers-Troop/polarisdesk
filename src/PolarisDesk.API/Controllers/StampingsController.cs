using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PolarisDesk.API.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PolarisDesk.Models.Stampings;

namespace PolarisDesk.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StampingsController : ControllerBase
    {
        private readonly PolarisDeskContext _context;

        public StampingsController(PolarisDeskContext context)
        {
            _context = context;
        }


        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult<IEnumerable<StampingDetail>>> Search(StampingFilter filter)
        {
            return await _context.Stampings
            .Where(a => a.UserId == filter.UserId
                        && filter.FromTimestamp.Date <= a.TimeStamp.Date
                        && a.TimeStamp.Date <= filter.ToTimeStamp.Date)
            .Include(a => a.User)
            .Include(f => f.StampingType)
            .Select(h => new StampingDetail()
            {
                StampingId = h.Id,
                StampingTypeId = h.StampingTypeId,
                UserId = h.UserId,
                UserName = h.User.UserName,
                Timestamp = h.TimeStamp,
                Description = h.StampingType.Description
            }).ToListAsync();
        }
        

        [HttpGet("{userId}")]
        public async Task<ActionResult<StampingDetail>> GetLastStamping(Guid userId)
        {
            var stamping = await _context.Stampings
            .Include(a => a.User)
            .Include(f => f.StampingType)
            .Select(h => new StampingDetail()
            {
                StampingId = h.Id,
                StampingTypeId = h.StampingTypeId,
                UserId = h.UserId,
                UserName = h.User.UserName,
                Timestamp = h.TimeStamp,
                Description = h.StampingType.Description
            }).FirstOrDefaultAsync(c => c.UserId == userId);

            if (stamping == null)
            {
                return NotFound();
            }
            return stamping;
        }

        [HttpPost]
        public async Task<ActionResult<NewStampingResponse>> PostStamping(NewStampingRequest newStamping)
        {
            var lastStamping = await _context.Stampings.OrderByDescending(a => a.TimeStamp).FirstOrDefaultAsync(a => a.UserId == newStamping.UserId && a.TimeStamp.Date == newStamping.TimeStamp.Date);
            var stampingsType = await _context.StampingTypes.ToListAsync();

            newStamping.StampingTypeId = lastStamping == null ? stampingsType.FirstOrDefault(a => a.Description.ToUpper() == "INGRESSO").Id : stampingsType.FirstOrDefault(a => a.Id != lastStamping.Id).Id;

            var stamping = new Stamping()
            {
                UserId = newStamping.UserId,
                TimeStamp = newStamping.TimeStamp,
                StampingTypeId = newStamping.StampingTypeId
            };
            await _context.Stampings.AddAsync(stamping);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetLastStamping", new { userId = stamping.UserId }, stamping);
        }

        private bool StampingExists(Guid id)
        {
            return _context.Stampings.Any(e => e.Id == id);
        }

        

    }
}

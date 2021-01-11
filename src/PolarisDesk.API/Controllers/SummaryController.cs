using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PolarisDesk.API.Data;
using PolarisDesk.Models.Stampings;
using PolarisDesk.Models.TimeUtility;

namespace PolarisDesk.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SummaryController : ControllerBase
    {
        private readonly PolarisDeskContext _context;

        public SummaryController(PolarisDeskContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult<IEnumerable<DailySummary>>> Elaborate(StampingFilter filter)
        {
            var currentUser = await _context.Users.Include(a => a.Profile).FirstOrDefaultAsync(a => a.ID == filter.UserId);

            var details = await _context.Stampings
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

            return (from day in details.Select(a => a.Timestamp.Date).Distinct()
                    let currentStampings = details.Where(a => a.Timestamp.Date == day.Date).ToList()
                    let totalMinutes = StampingTimeUtility.CalculateMinutes(currentStampings, currentUser.Profile.RemoveMinutes)
                    select new DailySummary()
                    {
                        Day = day.Date,
                        StampingDetails = currentStampings,
                        TotalWorkMinutes = totalMinutes,
                        UserId = filter.UserId,
                        UserName = currentUser.UserName,
                        IsCorrect = StampingTimeUtility.IsCorrect(totalMinutes, currentUser.Profile.DailyTotalMinutes),
                        DayName = day.Date.ToString("dddd"),
                        RemoveMinutes = currentUser.Profile.RemoveMinutes
                    }).ToList();
        }

    }
}

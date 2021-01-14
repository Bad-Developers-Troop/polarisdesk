using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PolarisDesk.API.Data;
using PolarisDesk.Models.Days;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PolarisDesk.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HolidaysController : ControllerBase
    {
        private readonly PolarisDeskContext _context;

        public HolidaysController(PolarisDeskContext context)
        {
            _context = context;
        }

        [HttpGet("{year}")]
        public async Task<ActionResult<IEnumerable<Holiday>>> GetUsers(int year)
        {
            return await _context.Holidays.Where(a=>a.Date.Year==year).ToListAsync();
        }



    }
}

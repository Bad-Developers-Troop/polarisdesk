using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PolarisDesk.API.WorkerServices;
using System;
using System.Linq;

namespace PolarisDesk.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly WeatherForecastControllerWorkerService _workerService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, WeatherForecastControllerWorkerService workerService)
        {
            _logger = logger;
            _workerService = workerService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Enumerable.Range(1, 5)
                .Select(index => this._workerService.GetForecast(DateTime.Now.AddDays(index)))
                .ToArray());
        }
    }
}

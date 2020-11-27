using System;
using PolarisDesk.Models;

namespace PolarisDesk.API.WorkerServices
{
    public class WeatherForecastControllerWorkerService
    {
        private readonly string[] summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        private readonly Random random;

        public WeatherForecastControllerWorkerService()
        {
            random = new Random();
        }

        public WeatherForecast GetForecast(DateTime date)
        {
            return new WeatherForecast
            {
                Date = date.Date,
                TemperatureC = this.random.Next(-20, 55),
                Summary = this.summaries[random.Next(this.summaries.Length)]
            };
        }
    }
}
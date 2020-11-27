using PolarisDesk.API.WorkerServices;
using Shouldly;
using System;
using Xunit;

namespace PolarisDesk.API.UnitTests
{
    public class WeatherForecastControllerWorkerServiceTests
    {
        [Fact]
        public void GetForecastShouldBeReturnAForecastForDate()
        {
            // Assert
            var date = DateTime.Now;
            var workerService = new WeatherForecastControllerWorkerService();

            // Act
            var forecast = workerService.GetForecast(date);

            // Arrange
            forecast.Date.ShouldBe(date.Date);
        }
    }
}

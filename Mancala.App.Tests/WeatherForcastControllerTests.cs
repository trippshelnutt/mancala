using Mancala.Controllers;
using Microsoft.Extensions.Logging;
using Moq;

namespace Mancala.App.Tests
{
    public class WeatherForcastControllerTests
    {
        private readonly Mock<ILogger<WeatherForecastController>> mockLogger;

        public WeatherForcastControllerTests()
        {
            mockLogger = new Mock<ILogger<WeatherForecastController>>();
        }

        [Fact]
        public void CanCreateWeatherForcastController()
        {
            _ = new WeatherForecastController(mockLogger.Object);
        }
    }
}
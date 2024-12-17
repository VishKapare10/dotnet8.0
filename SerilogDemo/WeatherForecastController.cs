using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SerilogDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            _logger.LogInformation("Handling GET request for weather forecast.");
            try
            {
                // Simulate a piece of logic
                _logger.LogWarning("This is a warning example.");
                throw new InvalidOperationException("Something went wrong.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while processing the request.");
            }

            return new[] { "Sunny", "Cloudy", "Rainy" };
        }
    }
}

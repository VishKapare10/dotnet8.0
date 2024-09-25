using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class WeatherForecastController : ControllerBase
{
    [Authorize]
    [HttpGet]
    public IActionResult GetWeatherForecast()
    {
        var forecast = new[] {
            new { Date = DateTime.Now, TemperatureC = 25, Summary = "Sunny" },
            // Add more weather data
        };
        return Ok(forecast);
    }
}

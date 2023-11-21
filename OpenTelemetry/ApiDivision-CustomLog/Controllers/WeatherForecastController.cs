using Microsoft.AspNetCore.Mvc;


namespace ApiDivision.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            var mmeIrma = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)],
                FrileuName="Mr Winter"
            })
            .ToArray();

            _logger.WeatherReturned(mmeIrma[0]);

            return mmeIrma;
        }
    }

    static partial class Log
    {
        [LoggerMessage(LogLevel.Information, "Weather returned {weather}")]
        public static partial void WeatherReturned(this ILogger logger,[LogProperties] WeatherForecast weather);

    }
}

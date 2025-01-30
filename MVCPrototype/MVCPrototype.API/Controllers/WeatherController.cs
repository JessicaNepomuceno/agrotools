using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MVCPrototype.Application.Services;

namespace MVCPrototype.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherController : ControllerBase
    {
        protected readonly IConfiguration _configuration;
        private readonly IWeatherService _weatherService;

        public WeatherController(IConfiguration configuration, IWeatherService weatherService)
        {
            _configuration = configuration;
            _weatherService = weatherService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var response = _weatherService.GetWeather();
            return StatusCode(200, response);
        }

        [HttpGet]
        [Route("Search")]
        public IActionResult Get(string startDate, string endDate)
        {
            var response = _weatherService.GetWeather(startDate, endDate);
            return StatusCode(200, response);
        }

        [HttpGet]
        [Route("Calendar")]
        public IActionResult GetCalendar()
        {
            var response = _weatherService.GetWeather(DateTime.Now);
            return StatusCode(200, response);
        }
    }
}

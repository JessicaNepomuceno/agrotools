using MVCPrototype.Domain.Entities;

namespace MVCPrototype.Application.Services
{
    public interface IWeatherService
    {
        IEnumerable<WeatherForecast> GetWeather();
    }
}

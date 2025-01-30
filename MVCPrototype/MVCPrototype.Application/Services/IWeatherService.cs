using MVCPrototype.Domain.Entities;

namespace MVCPrototype.Application.Services
{
    public interface IWeatherService
    {
        IEnumerable<WeatherForecast> GetWeather();
        IEnumerable<WeatherForecast> GetWeather(string startDate, string endDate);
        IEnumerable<WeatherForecast> GetWeather(DateTime currentDate);
    }
}

using MVCPrototype.Domain.Entities;
using System.Globalization;

namespace MVCPrototype.Application.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly CultureInfo Culture = new CultureInfo("pt-BR");
        private static readonly string[] Summaries = new[]
        {
            "Frio", "Chuvoso", "Nublado", "Ensolarado"
        };

        public WeatherService() { }

        public IEnumerable<WeatherForecast> GetWeather()
        {
            return Enumerable.Range(0, 7).Select(index =>
            {
                var dateTime = DateTime.Now.AddDays(index);
                return new WeatherForecast
                {
                    Date = DateOnly.FromDateTime(dateTime).ToString("dd/MM/yyyy", Culture),
                    DayOfWeek = dateTime.ToString("dddd", Culture),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                };
            })
           .ToArray();            
        }
    }
}

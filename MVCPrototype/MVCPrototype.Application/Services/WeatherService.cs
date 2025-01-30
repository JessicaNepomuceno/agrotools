using MVCPrototype.Domain.Entities;
using System.Globalization;
using System.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
                return NewMethod(dateTime);
            })
            .ToArray();
        }        

        public IEnumerable<WeatherForecast> GetWeather(string startDate, string endDate)
        {
            if (DateTime.TryParseExact(startDate, "dd/MM/yyyy", Culture, System.Globalization.DateTimeStyles.None, out var startDateResult) &&
                 DateTime.TryParseExact(endDate, "dd/MM/yyyy", Culture, System.Globalization.DateTimeStyles.None, out var endDateResult))
            {
                if (startDateResult <= endDateResult)
                {                    
                    return Enumerable.Range(0, (endDateResult - startDateResult).Days + 1).Select(index =>
                    {
                        var dateTime = startDateResult.AddDays(index);
                        return NewMethod(dateTime);
                    })
                   .ToArray();
                }
                
            }
            return [new WeatherForecast()];
        }

        public IEnumerable<WeatherForecast> GetWeather(DateTime currentDate)
        {            
            return Enumerable.Range(1, DateTime.DaysInMonth(currentDate.Year, currentDate.Month)).Select(index =>
            {
                var dateTime = new DateTime(currentDate.Year, currentDate.Month, index);
                return NewMethod(dateTime);
            }).ToArray();
        }

        private WeatherForecast NewMethod(DateTime dateTime)
        {
            return new WeatherForecast
            {
                Date = DateOnly.FromDateTime(dateTime).ToString("dd/MM/yyyy", Culture),
                DayOfWeek = dateTime.ToString("dddd", Culture),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            };
        }
    }
}

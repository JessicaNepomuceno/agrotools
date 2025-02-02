using Microsoft.Extensions.Localization;
using MVCPrototype.Domain.Entities;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MVCPrototype.Application.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly IStringLocalizer<WeatherService> _localizer;
        private readonly CultureInfo culture = new CultureInfo("pt-BR");
        private readonly Summary[] summaries;

        public WeatherService(IStringLocalizer<WeatherService> localizer)
        {
            _localizer = localizer;
            summaries = 
            [  
                new Summary { Name = _localizer["Freezing"], IconSrc = "/icons/snowflake-solid.svg" },
                new Summary { Name = _localizer["Raining"], IconSrc = "/icons/rain-solid.svg" },
                new Summary { Name = _localizer["Smog"], IconSrc = "/icons/smog-solid.svg" },
                new Summary { Name = _localizer["Sunny"], IconSrc = "/icons/sun-solid.svg" } 
            ];
        }       

        public IEnumerable<WeatherForecast> GetWeather()
        {
            return Enumerable.Range(0, 7).Select(index =>
            {
                var dateTime = DateTime.Now.AddDays(index);
                return GetWeatherForecast(dateTime);
            })
            .ToArray();
        }

        public IEnumerable<WeatherForecast> GetWeather(string startDate, string endDate)
        {
            if (DateTime.TryParseExact(startDate, "dd/MM/yyyy", culture, System.Globalization.DateTimeStyles.None, out var startDateResult) &&
                 DateTime.TryParseExact(endDate, "dd/MM/yyyy", culture, System.Globalization.DateTimeStyles.None, out var endDateResult))
            {
                if (startDateResult <= endDateResult)
                {
                    return Enumerable.Range(0, (endDateResult - startDateResult).Days + 1).Select(index =>
                    {
                        var dateTime = startDateResult.AddDays(index);
                        return GetWeatherForecast(dateTime);
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
                return GetWeatherForecast(dateTime);
            }).ToArray();
        }

        private WeatherForecast GetWeatherForecast(DateTime dateTime)
        {
            var index = Random.Shared.Next(summaries.Length);
            return new WeatherForecast
            {
                Date = DateOnly.FromDateTime(dateTime).ToString("dd/MM/yyyy", culture),
                DayOfWeek = dateTime.ToString("dddd", culture),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = summaries[index].Name,
                icon = summaries[index].IconSrc,
            };
        }        
    }
}

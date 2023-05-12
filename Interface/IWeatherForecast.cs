using RapidApi_Weather.Models;

namespace RapidApi_Weather.Interface
{
    public interface IWeatherForecast
    {
        public Task<List<FindPlaces>> getFindPlaces(string text);
        public Task<Current> getCurrentWeather(string city, string country);
        public Task<DailyWeather> postDailyWeather(string city, string country);
        public Task<Location> getAstroData(string city, string country);
    }
}

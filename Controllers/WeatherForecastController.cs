using Microsoft.AspNetCore.Mvc;
using RapidApi_Weather.Interface;
using RapidApi_Weather.Models;
using static System.Net.Mime.MediaTypeNames;

namespace RapidApi_Weather.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly IWeatherForecast _weather;

        public WeatherForecastController(IWeatherForecast WeatherForecast)
        {
            _weather = WeatherForecast;
        }

        [HttpPost]
        [Route("Get_Find_Places")]
        public async Task<ActionResult<IEnumerable<FindPlaces>>> getFindPlaces(string text)
        {
            return Ok(await _weather.getFindPlaces(text));
        }

        [HttpPost]
        [Route("Get_Current_Weather")]
        public async Task<ActionResult<IEnumerable<FindPlaces>>> getCurrentWeather(string city, string country)
        {
            return Ok(await _weather.getCurrentWeather(city, country));
        }

        [HttpPost]
        [Route("Get_Daily_Weather")]
        public async Task<ActionResult<IEnumerable<FindPlaces>>> postDailyWeather(string city, string country)
        {
            return Ok(await _weather.postDailyWeather(city,country));
        }


    }
}
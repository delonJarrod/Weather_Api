using Newtonsoft.Json;
using RapidApi_Weather.Interface;
using RapidApi_Weather.Models;
using System;
using System.Diagnostics.Metrics;
using System.Net.Http;
using static System.Net.Mime.MediaTypeNames;

namespace RapidApi_Weather.Logic
{
    public class WeatherForecast : IWeatherForecast
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        // Find places based on city
        public async Task<List<FindPlaces>> getFindPlaces(string text)
        {
            var response = await GetMethod("https://ai-weather-by-meteosource.p.rapidapi.com/find_places?text=" + text + "&language=en");
            List<FindPlaces> FindPlaces = JsonConvert.DeserializeObject<List<FindPlaces>>(response);
            return FindPlaces;
        }

        // Get current weather
        public async Task<Current> getCurrentWeather(string city, string country)
        {
            List<FindPlaces> FindPlaces = await getFindPlaces(city);
            FindPlaces place = FindPlaces.Where(x => x.country.ToLower().Replace(" ", "") == country.ToLower().Replace(" ", "")).FirstOrDefault();
            var response = await GetMethod("https://ai-weather-by-meteosource.p.rapidapi.com/current?place_id=" + place.place_id);
            Current Current = JsonConvert.DeserializeObject<Current>(response);
            return Current;
        }

        // Get daily weather
        public async Task<DailyWeather> postDailyWeather(string city, string country)
        {

            List<FindPlaces> FindPlaces = await getFindPlaces(city);
            FindPlaces place = FindPlaces.Where(x => x.country.ToLower().Replace(" ", "") == country.ToLower().Replace(" ", "")).FirstOrDefault();
            var response = await GetMethod("https://ai-weather-by-meteosource.p.rapidapi.com/daily?place_id=" + place.place_id);
            DailyWeather DailyWeather = JsonConvert.DeserializeObject<DailyWeather>(response);
            return DailyWeather;
        }
        
        public async Task<Location> getAstroData(string city, string country)
        {
            List<FindPlaces> FindPlaces = await getFindPlaces(city);
            FindPlaces place = FindPlaces.Where(x => x.country.ToLower().Replace(" ", "") == country.ToLower().Replace(" ", "")).FirstOrDefault();
            var response = await GetMethod("https://ai-weather-by-meteosource.p.rapidapi.com/astro?place_id=" + place.place_id);
            Location astroData = JsonConvert.DeserializeObject<Location>(response);


            DateTime sunStartDate, sunEndDate, nightStartDate, nightEndDate;

            foreach (var item in astroData?.astro?.data ?? Enumerable.Empty<AstroData>())
            {
                // Check for null values before parsing dates
                if (DateTime.TryParse(item.sun?.rise, out  sunStartDate) && DateTime.TryParse(item.sun?.set, out  sunEndDate)
                    && DateTime.TryParse(item.moon?.rise, out  nightStartDate) && DateTime.TryParse(item.moon?.set, out  nightEndDate))
                {
                    var sunhours = Math.Round((sunEndDate - sunStartDate).TotalHours, 2);
                    var nighthours = Math.Round((nightEndDate - nightStartDate).TotalHours, 2);

                    item.hours_Of_Sun_Time = sunhours.ToString() + " Hours";
                    item.hours_Of_Night_Time = nighthours.ToString() + " Hours";
                }
                else
                {
                    // Handle null or invalid values
                    item.hours_Of_Sun_Time = "N/A";
                    item.hours_Of_Night_Time = "N/A";
                }
            }
            return astroData;
        }


        public async Task<string> GetMethod(string url)
        {
            // Getting the weather data
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("X-RapidAPI-Key", "1dcecfd511msha78bd4104e04264p11ee1fjsnf767f971b342");
            request.Headers.Add("X-RapidAPI-Host", "ai-weather-by-meteosource.p.rapidapi.com");
            using var response = await _httpClient.SendAsync(request);
            var body = await response.Content.ReadAsStringAsync();
            return body;
        }

    }
}

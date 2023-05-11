namespace RapidApi_Weather.Models
{
    public class DailyWeather
    {
        public string Lat { get; set; }
        public string Lon { get; set; }
        public int Elevation { get; set; }
        public string Units { get; set; }
        public DailyData Daily { get; set; }
    }
    public class DailyData
    {
        public List<DailyWeatherData> Data { get; set; }
    }

    public class DailyWeatherData
    {
        public string Day { get; set; }
        public string Weather { get; set; }
        public int Icon { get; set; }
        public string Summary { get; set; }
        public int Predictability { get; set; }
        public double Temperature { get; set; }
        public double TemperatureMin { get; set; }
        public double TemperatureMax { get; set; }
        public double FeelsLike { get; set; }
        public double FeelsLikeMin { get; set; }
        public double FeelsLikeMax { get; set; }
        public double WindChill { get; set; }
        public double WindChillMin { get; set; }
        public double WindChillMax { get; set; }
        public double DewPoint { get; set; }
        public double DewPointMin { get; set; }
        public double DewPointMax { get; set; }
        public DailyWindData Wind { get; set; }
        public int CloudCover { get; set; }
        public double Pressure { get; set; }
        public DailyPrecipitationData Precipitation { get; set; }
        public ProbabilityData Probability { get; set; }
        public double Ozone { get; set; }
        public int Humidity { get; set; }
        public double Visibility { get; set; }
    }

    public class DailyWindData
    {
        public double Speed { get; set; }
        public double Gusts { get; set; }
        public string Direction { get; set; }
        public int Angle { get; set; }
    }

    public class DailyPrecipitationData
    {
        public double Total { get; set; }
        public string Type { get; set; }
    }

    public class ProbabilityData
    {
        public double Precipitation { get; set; }
        public double Storm { get; set; }
        public double Freeze { get; set; }
    }
}

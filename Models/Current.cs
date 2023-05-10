namespace RapidApi_Weather.Models
{
    public class Current
    {
        public string lat { get; set; }
        public string lon { get; set; }
        public string elevation { get; set; }
        public string timezone { get; set; }
        public string units { get; set; }
        public CurrentData current { get; set; }
    }
    public class CurrentData
    {
        public string icon { get; set; }
        public string icon_num { get; set; }
        public string summary { get; set; }
        public string temperature { get; set; }
        public string feels_like { get; set; }
        public string wind_chill { get; set; }
        public string dew_point { get; set; }
        public WindData wind { get; set; }
        public PrecipitationData precipitation { get; set; }
        public string cloud_cover { get; set; }
        public string ozone { get; set; }
        public string pressure { get; set; }
        public string uv_index { get; set; }
        public string humidity { get; set; }
        public string visibility { get; set; }
    }

    public class WindData
    {
        public string speed { get; set; }
        public string gusts { get; set; }
        public string angle { get; set; }
        public string dir { get; set; }
    }

    public class PrecipitationData
    {
        public string total { get; set; }
        public string type { get; set; }
    }
}

namespace RapidApi_Weather.Models
{
    public class Sun
    {
        public string rise { get; set; }
        public string set { get; set; }
        public bool always_up { get; set; }
        public bool always_down { get; set; }
    }

    public class Moon
    {
        public string phase { get; set; }
        public string rise { get; set; }
        public string set { get; set; }
        public bool always_up { get; set; }
        public bool always_down { get; set; }
    }

    public class AstroData
    {
        public string day { get; set; }
        public string? hours_Of_Sun_Time{ get; set; }
        public string? hours_Of_Night_Time { get; set; }
        public Sun sun { get; set; }
        public Moon moon { get; set; }
    }

    public class Astro
    {
        public List<AstroData> data { get; set; }
    }

    public class Location
    {
        public string lat { get; set; }
        public string lon { get; set; }
        public int elevation { get; set; }
        public string timezone { get; set; }
        public Astro astro { get; set; }
    }
}

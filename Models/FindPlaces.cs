namespace RapidApi_Weather.Models
{
    public class FindPlaces
    {
        public string name { get; set; }
        public string place_id { get; set; }
        public string adm_area1 { get; set; }
        public string adm_area2 { get; set; }
        public string country { get; set; }
        public string lat { get; set; }
        public string lon { get; set; }
        public string timezone { get; set; }
        public string type { get; set; }
    }
}

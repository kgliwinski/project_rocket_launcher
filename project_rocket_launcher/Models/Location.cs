namespace project_rocket_launcher.Models
{
    public class Location
    {
        public int id { get; set; }
        public string url { get; set; }
        public string name { get; set; }
        public string countryCode { get; set; }
        public string map_image { get; set; }
        public int totalLaunchCount { get; set; }
        public int totalLandingCount { get; set; }
    }
}

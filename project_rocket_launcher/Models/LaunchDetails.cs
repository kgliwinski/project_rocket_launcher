
namespace project_rocket_launcher.Models
{
    /// <summary>
    /// Launch details based on API schema
    /// https://ll.thespacedevs.com/2.2.0/swagger/#/config/config_eventtype_list
    /// </summary>
    public class LaunchDetails
    {
        public string id { get; set; }
        public string url { get; set; }
        public string slug { get; set; }
        public string? flight_club_url { get; set; }
        public string? r_spacex_api_id { get; set; }
        public string name { get; set; }
        
        public LaunchStatus status { get; set; }
    
        public string lastUpdate { get; set; }
        //public List<LaunchUpdate> updates { get; set; }

        //public string? net { get; set; }

        public string? window_end { get; set; }
        public string? window_start { get; set; }
        public int? probability { get; set; }
        public string? hold_reason { get; set; }
        public string? fail_rason { get; set; }

        public string image { get; set; }
        //public string? hashtag { get; set; }
    }
}

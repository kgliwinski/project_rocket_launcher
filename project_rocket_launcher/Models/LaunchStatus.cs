namespace project_rocket_launcher.Models
{
    /// <summary>
    /// Launch status API schema
    /// https://ll.thespacedevs.com/2.2.0/swagger/#/config/config_eventtype_list
    /// </summary>
    public class LaunchStatus
    {
        public int id { get; set; }
        public string name { get; set; }
        public string abbrev { get; set; }
        public string description { get; set; }
    }
}

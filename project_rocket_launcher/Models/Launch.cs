namespace project_rocket_launcher.Models
{
    /// <summary>
    /// Class represents rocket launch
    /// </summary>
    public class Launch
    {
        /// <summary>
        /// True - it is favourite launch
        /// False - it isn't favourite launch
        /// </summary>
        public bool isFavourite { get; set; }
        /// <summary>
        /// Launch details
        /// </summary>
        public LaunchDetails details { get; set; }
    }
}

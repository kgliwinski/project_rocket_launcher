using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace project_rocket_launcher.Models
{
    /// <summary>
    /// Favourite launch database context
    /// </summary>
    public class FavouriteLaunch : Launch
    {
        /// <summary>
        /// Favourite launch ID [PK]
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// API launch id
        /// </summary>
        public string LaunchId { get; set; } = string.Empty;

        /// <summary>
        /// Launch detail in json format
        /// </summary>
        public string LaunchDetailsJson { get; set; }

    }
}
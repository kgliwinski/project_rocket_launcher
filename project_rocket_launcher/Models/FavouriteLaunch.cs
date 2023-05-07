using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace project_rocket_launcher.Models
{
    public class FavouriteLaunch : Launch
    {
        [Key]
        public int Id { get; set; }

        public string LaunchId { get; set; } = string.Empty;

        public string LaunchDetailsJson { get; set; }

    }
}
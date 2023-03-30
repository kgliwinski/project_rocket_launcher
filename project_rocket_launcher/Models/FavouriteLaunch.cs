using System.ComponentModel.DataAnnotations;

namespace project_rocket_launcher.Models
{
    public class FavouriteLaunch
    {
        [Key]
        public int Id { get; set; }
        public string LaunchId { get; set; } = string.Empty;

    }
}

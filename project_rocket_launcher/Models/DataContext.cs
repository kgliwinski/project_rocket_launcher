global using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace project_rocket_launcher.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<FavouriteLaunch> FavouritesLaunches { get; set; }
    }
}

global using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace project_rocket_launcher.Models
{
    /// <summary>
    /// Data contex for data base
    /// </summary>
    public class DataContext : DbContext
    {
        /// <summary>
        /// Data base constructor
        /// </summary>
        /// <param name="options"></param>
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        /// <summary>
        /// Data base set of favourite launches
        /// </summary>
        public DbSet<FavouriteLaunch> FavouritesLaunches { get; set; }
    }
}

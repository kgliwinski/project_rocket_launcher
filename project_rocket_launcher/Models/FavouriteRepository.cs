using Newtonsoft.Json;

namespace project_rocket_launcher.Models
{
    /// <summary>
    /// Favourite repository interface implementation
    /// </summary>
    public class FavouriteRepository : IFavouriteRepository
    {
        /// <summary>
        /// Data base
        /// </summary>
        private readonly DataContext _context;

        /// <summary>
        /// Favourite repository constructor
        /// </summary>
        /// <param name="context">Data base context</param>
        public FavouriteRepository(DataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get launch from database
        /// </summary>
        /// <param name="id">Launch id</param>
        /// <returns>launch info</returns>
        public FavouriteLaunch Get(int id)
        {
            var launch = _context.FavouritesLaunches.SingleOrDefault(x => x.Id == id);
            return launch;
        }

        /// <summary>
        /// Add launch to database
        /// </summary>
        /// <param name="launch">launcg id</param>
        public void Add(FavouriteLaunch launch)
        {
            _context.FavouritesLaunches.Add(launch);
            _context.SaveChanges();
        }

        /// <summary>
        /// Get all launches from database
        /// </summary>
        /// <returns>List of launches</returns>
        public IQueryable<FavouriteLaunch> GetAllFavourites()
        {
            return _context.FavouritesLaunches;
        }

        /// <summary>
        /// Delete launch from database
        /// </summary>
        /// <param name="id">Launch id</param>
        public void Delete(string id)
        {
            var launch = _context.FavouritesLaunches.FirstOrDefault(x => x.LaunchId.Equals(id));
            if (launch != null)
            {
                _context.Remove(launch);
                _context.SaveChanges();
            }
        }


    }
}

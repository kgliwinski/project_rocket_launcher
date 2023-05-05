using Newtonsoft.Json;

namespace project_rocket_launcher.Models
{
    public class FavouriteRepository : IFavouriteRepository
    {
        private readonly DataContext _context;

        public FavouriteRepository(DataContext context)
        {
            _context = context;
        }

        public FavouriteLaunch Get(int id)
        {
            var launch = _context.FavouritesLaunches.SingleOrDefault(x => x.Id == id);
            return launch;
        }

        public void Add(FavouriteLaunch launch)
        {
            _context.FavouritesLaunches.Add(launch);
            _context.SaveChanges();
        }


        public IQueryable<FavouriteLaunch> GetAllFavourites()
        {
            return _context.FavouritesLaunches;
        }

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

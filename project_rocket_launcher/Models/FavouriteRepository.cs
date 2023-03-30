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
            return _context.FavouritesLaunches.SingleOrDefault(x => x.Id == id);
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

        //public void Update(int id, FavouriteLaunch launch) 
        //{
        //    //FavouriteLaunch favourite = _context.FavouritesLaunches.SingleOrDefault(x => x.Id == id);

        //    //if (favourite != null)
        //    //{
        //    //    favourite
        //    //}
        //}

    }
}

namespace project_rocket_launcher.Models
{
    public interface IFavouriteRepository
    {
        FavouriteLaunch Get(int id);
        //IQueryable<FavouriteLaunch> GetAllFavourites();
        void Add(FavouriteLaunch favouriteLaunch);

        IQueryable<FavouriteLaunch> GetAllFavourites();
    }
}

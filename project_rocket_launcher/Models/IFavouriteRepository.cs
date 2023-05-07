namespace project_rocket_launcher.Models
{
    /// <summary>
    /// Favourite launches interface
    /// </summary>
    public interface IFavouriteRepository
    {
        /// <summary>
        /// Get favourite launch
        /// </summary>
        /// <param name="id">Launch id</param>
        /// <returns>favourite launch</returns>
        FavouriteLaunch Get(int id);

        /// <summary>
        /// Add favourite launch
        /// </summary>
        /// <param name="favouriteLaunch">Favourite launch info</param>
        void Add(FavouriteLaunch favouriteLaunch);

        /// <summary>
        /// Get all launches
        /// </summary>
        /// <returns>List of favourite launches</returns>
        IQueryable<FavouriteLaunch> GetAllFavourites();

        /// <summary>
        /// Delete favourite launch
        /// </summary>
        /// <param name="launch_id">Launch id</param>
        void Delete(string launch_id);
    }
}

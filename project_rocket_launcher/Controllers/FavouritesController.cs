using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using project_rocket_launcher.Models;

namespace project_rocket_launcher.Controllers
{
    /// <summary>
    /// Favourite launches controller
    /// </summary>
    public class FavouritesController : Controller
    {
        private readonly IFavouriteRepository favouriteRepository;
        /// <summary>
        ///  Favourite Launches Controller Constructor
        /// </summary>
        /// <param name="_favouriteRepository"> Favourite Repository interface </param>
        public FavouritesController(IFavouriteRepository _favouriteRepository)
        {
            favouriteRepository = _favouriteRepository;
        }

        /// <summary>
        /// Get favourite launches and change view to Favourites/Index
        /// </summary>
        /// <returns> Favourite Launches view </returns>
        public ActionResult Index()
        {
            ViewBag.Launches = TheSpaceLaunch.getFavouriteLaunches(favouriteRepository.GetAllFavourites());
            return View();
        }

        /// <summary>
        /// Get detail information abourt favoruite launch
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Favourite launch detail view</returns>
        public ActionResult Details(int id)
        {
            return View();
        }

        /// <summary>
        /// Create favourite launch
        /// </summary>
        /// <returns> Favourite launch view</returns>
        public ActionResult Create()
        {
            return View(new FavouriteLaunch());
        }

        /// <summary>
        /// Create favourite launch from loaded list 
        /// </summary>
        /// <param name="launch">Launch details</param>
        /// <returns> Current view </returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FavouriteLaunch launch)
        {
            favouriteRepository.Add(launch);
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Edit favourite launch
        /// </summary>
        /// <param name="id"> Launch id</param>
        /// <returns>Favourite launch view</returns>
        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        /// <summary>
        /// Delete favorurite launch
        /// </summary>
        /// <param name="id">Launch id</param>
        /// <returns>Favourite launch view</returns>
        public ActionResult Delete(int id)
        {
            return View();
        }

        /// <summary>
        ///  Delete favourite launch
        /// </summary>
        /// <param name="id">Launch id</param>
        /// <param name="collection">Launch collection</param>
        /// <returns>Favourite launch view</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

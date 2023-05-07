using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using project_rocket_launcher.Models;

namespace project_rocket_launcher.Controllers
{
    /// <summary>
    /// Rocket launch contriller
    /// </summary>
    public class RocketLaunchesController : Controller
    {
        private readonly IFavouriteRepository favouriteRepository;

        public RocketLaunchesController(IFavouriteRepository _favouriteRepository)
        {
            favouriteRepository = _favouriteRepository;
        }

        /// <summary>
        /// Get upcoming launches and create launch view
        /// </summary>
        /// <returns>Rocket launches view</returns>
        public IActionResult RocketLaunches()
        {

            ViewBag.Launches = TheSpaceLaunch.convertToLaunch(
                TheSpaceLaunch.getUpcomingLaunches(),
                favouriteRepository.GetAllFavourites());
            return View();
        }

        /// <summary>
        /// Get launch details and create launch detail view
        /// </summary>
        /// <param name="launchID">launch id</param>
        /// <returns>Launch detail view</returns>
        public IActionResult LaunchDetails(string? launchID)
        {
            if (launchID == null)
            {
                ViewBag.LaunchDetails = null;
            }
            else
            {
                LaunchDetails launchDetails = TheSpaceLaunch.getUpcomingLaunchById(launchID);
                Console.WriteLine(launchDetails.id);
                ViewBag.LaunchDetails = launchDetails;
            }
            return View();
        }

        /// <summary>
        /// Add lauch to favourite
        /// </summary>
        /// <param name="launchID">launch id</param>
        /// <returns>Rocket launches view</returns>
        public IActionResult AddToFavourite(string launchID)
        {
            LaunchDetails launchDetails = TheSpaceLaunch.getUpcomingLaunchById(launchID);
            string json = JsonConvert.SerializeObject(launchDetails);
            FavouriteLaunch favourite = new FavouriteLaunch() { LaunchId = launchID, LaunchDetailsJson = json };
            favouriteRepository.Add(favourite);

            return RedirectToAction(nameof(RocketLaunches));
        }

        /// <summary>
        /// Remove launch from favoruites
        /// </summary>
        /// <param name="launchID">Launch id</param>
        /// <returns>Rocket launches view</returns>
        public IActionResult RemoveFromFavourite(string launchID)
        {
            favouriteRepository.Delete(launchID);
            return RedirectToAction(nameof(RocketLaunches));
        }

        /// <summary>
        /// Create favourite launches view
        /// </summary>
        /// <returns>Favourite launches view</returns>
        public IActionResult FavouritesLaunches()
        {
            //IList<Launch> result = ;
            //result.ForEach((item) =>  launches.Add(item.Clone()));

            //Console.WriteLine(launches.Count);
            return View();
        }



    }
}

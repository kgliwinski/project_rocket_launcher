using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using project_rocket_launcher.Models;

namespace project_rocket_launcher.Controllers
{
    public class RocketLaunchesController : Controller
    {
        private readonly IFavouriteRepository favouriteRepository;

        public RocketLaunchesController(IFavouriteRepository _favouriteRepository)
        {
            favouriteRepository = _favouriteRepository;
        }

        public IActionResult RocketLaunches()
        {

            ViewBag.Launches = TheSpaceLaunch.convertToLaunch(
                TheSpaceLaunch.getUpcomingLaunches(), 
                favouriteRepository.GetAllFavourites());
            return View();
        }

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

        public IActionResult AddToFavourite(string launchID)
        {
            LaunchDetails launchDetails = TheSpaceLaunch.getUpcomingLaunchById(launchID);
            string json = JsonConvert.SerializeObject(launchDetails);
            FavouriteLaunch favourite = new FavouriteLaunch() { LaunchId = launchID, LaunchDetailsJson = json};
            favouriteRepository.Add(favourite);

            return RedirectToAction(nameof(RocketLaunches));
        }

        public IActionResult RemoveFromFavourite(string launchID)
        {
            favouriteRepository.Delete(launchID);
            return RedirectToAction(nameof(RocketLaunches));
        }

        public IActionResult FavouritesLaunches()
        {
            //IList<Launch> result = ;
            //result.ForEach((item) =>  launches.Add(item.Clone()));

            //Console.WriteLine(launches.Count);
            return View();
        }



    }
}

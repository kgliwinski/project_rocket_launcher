using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using project_rocket_launcher.Models;

namespace project_rocket_launcher.Controllers
{
    public class RocketLaunchesController : Controller
    {
        //public IList<Launch> launches = new List<Launch>();
        public IActionResult RocketLaunches()
        {
            //IList<Launch> result = ;
            //result.ForEach((item) =>  launches.Add(item.Clone()));

            //Console.WriteLine(launches.Count);
            ViewBag.Launches = TheSpaceLaunch.getUpcomingLaunches();
            return View();
        }

        //[HttpGet]
        [Route("{launchID}")]
        public IActionResult LaunchDetails(string? launchID)
        {
            if (launchID == null) 
            {
                ViewBag.LaunchDetails = null;
            } 
            else
            {
                Launch launchDetails = TheSpaceLaunch.getUpcomingLaunchById(launchID);
                Console.WriteLine(launchDetails.id);
                ViewBag.LaunchDetails = launchDetails;
            }
            return View();
        }



    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using project_rocket_launcher.Models;

namespace project_rocket_launcher.Controllers
{
    public class RocketLaunchesController : Controller
    {
        IList<Launch> launches = new List<Launch>();
        public IActionResult RocketLaunches()
        {
            launches = TheSpaceLaunch.getUpcomingLaunches();
            ViewBag.Launches = launches;
            return View();
        }
    }
}

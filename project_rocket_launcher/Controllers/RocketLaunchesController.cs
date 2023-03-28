using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query;

namespace project_rocket_launcher.Controllers
{
    public class RocketLaunchesController : Controller
    {
        public IActionResult RocketLaunches()
        {
            return View();
        }

        private void getLaunches()
        {
            using(var client = new HttpClient())
            {
                var endpoint = new Uri("https://lldev.thespacedevs.com/2.2.0/launch/f9e39cde-55d5-4ee5-9bd9-dd855f55b3eb");
                var result = client.GetAsync(endpoint).Result.Content.ReadAsStringAsync().Result;
                Console.WriteLine(result);
            }
        }

        public IActionResult onButton(string button)
        {
            TempData["button_rocket_launches"] = "Helloo world!";
            Console.WriteLine("Hello");
            getLaunches();
            return RedirectToAction("RocketLaunches");
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using project_rocket_launcher.Models;

namespace project_rocket_launcher.Controllers
{
    public class FavouritesController : Controller
    {
        private readonly IFavouriteRepository favouriteRepository;

        public FavouritesController(IFavouriteRepository _favouriteRepository)
        {
            favouriteRepository = _favouriteRepository;
        }

        // GET: FavouritesController
        public ActionResult Index()
        {
            ViewBag.Launches = TheSpaceLaunch.getFavouriteLaunches(favouriteRepository.GetAllFavourites());
            return View();
        }

        // GET: FavouritesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FavouritesController/Create
        public ActionResult Create()
        {
            return View(new FavouriteLaunch());
        }

        // POST: FavouritesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FavouriteLaunch launch)
        {
            favouriteRepository.Add(launch);
            return RedirectToAction(nameof(Index));
        }

        // GET: FavouritesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FavouritesController/Edit/5
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

        // GET: FavouritesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FavouritesController/Delete/5
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

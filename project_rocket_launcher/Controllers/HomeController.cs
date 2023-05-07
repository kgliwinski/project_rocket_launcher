using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using project_rocket_launcher.Models;

namespace project_rocket_launcher.Controllers;

/// <summary>
/// Home controller
/// </summary>
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    /// <summary>
    /// Home controller constructor
    /// </summary>
    /// <param name="logger">Home controller logger</param>
    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Create index view
    /// </summary>
    /// <returns>Index view</returns>
    public IActionResult Index()
    {
        return View();
    }

    /// <summary>
    /// Create privacy view
    /// </summary>
    /// <returns>Privacy view</returns>
    public IActionResult Privacy()
    {
        return View();
    }

    /// <summary>
    /// Create error view
    /// </summary>
    /// <returns>Error view</returns>
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}


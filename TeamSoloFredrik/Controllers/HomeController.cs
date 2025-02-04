using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TeamSoloFredrik.Models;
using TeamSoloFredrik.Models.ViewModels;
using TeamSoloFredrik.Services;

namespace TeamSoloFredrik.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger,IMovieService movieService)
        {
            _logger = logger;
            _movieService = movieService;
        }

        public IActionResult Index()
        {
            CustomerMovieOrdersVM homeVM = _movieService.GetAllData();

            return View(homeVM);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

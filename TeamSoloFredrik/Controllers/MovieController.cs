using Microsoft.AspNetCore.Mvc;
using TeamSoloFredrik.Data;
using TeamSoloFredrik.Models.Db;
using TeamSoloFredrik.Services;

namespace TeamSoloFredrik.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly SoloDBContext _db;

        public MovieController(IMovieService movieService, SoloDBContext db)
        {
            _movieService = movieService;
            _db = db;
        }
        public IActionResult Index()
        {
            return RedirectToAction("MoviesList");
        }

        // Add Movie
        [HttpGet]
        public IActionResult AddMovie()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddMovie(Movie movies)
        {
            if (ModelState.IsValid && movies != null)
            {
                _movieService.AddMovie(movies);
                ViewBag.Movie = "Movie added Successfully!";
            }
            else
                ViewBag.Movie = "Something went wrong! Movie did not get added to the database.";

            return View();
        }

        // Display All Movies
        public IActionResult MoviesList()
        {
            var movieList = _movieService.GetMovies();
            return View(movieList);
        }
    }
}

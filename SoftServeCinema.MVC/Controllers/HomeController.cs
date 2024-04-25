using Microsoft.AspNetCore.Mvc;
using SoftServeCinema.Core.Exceptions;
using SoftServeCinema.Core.Interfaces.Services;
using SoftServeCinema.MVC.Models;
using System.Diagnostics;

namespace SoftServeCinema.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMovieService _movieService;

        public HomeController(ILogger<HomeController> logger, IMovieService movieService)
        {
            _logger = logger;
            _movieService = movieService;
        }

        public IActionResult Index()
        {
            return View();
        }

        //public async Task<string> IndexAsync()
        //{
        //    string movies = string.Empty;
        //    foreach (var movie in await _movieService.GetMoviesByGenresAsync([1, 3]))
        //    {
        //        movies += " | " + movie.Title;
        //    }
        //    return movies;

        //    //try
        //    //{
        //    //    var movie = await _movieService.GetMovieByIdAsync(5);
        //    //    return movie.TrailerUrl;
        //    //}
        //    //catch (EntityNotFoundException)
        //    //{
        //    //    return "not found";
        //    //}
        //}

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

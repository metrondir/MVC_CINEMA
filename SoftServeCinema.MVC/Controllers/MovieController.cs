using Microsoft.AspNetCore.Mvc;
using SoftServeCinema.Core.Interfaces.Services;
using X.PagedList;

namespace SoftServeCinema.MVC.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        public async Task<IActionResult> Index(int page = 1, int pageSize = 10)
        {
            if (page <= 0) page = 1;

            var movies = await _movieService.GetActualsAsync();

            if (movies.Count() <= (page - 1) * pageSize) return BadRequest();

            return View(await movies.ToPagedListAsync(page, pageSize));
        }
    }
}

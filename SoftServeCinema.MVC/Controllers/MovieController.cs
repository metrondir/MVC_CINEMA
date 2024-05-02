using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SoftServeCinema.Core.DTOs.Movies;
using SoftServeCinema.Core.Exceptions;
using SoftServeCinema.Core.Interfaces.Services;
using SoftServeCinema.MVC.Helpers;
using X.PagedList;

namespace SoftServeCinema.MVC.Controllers
{
    
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly IGenreService _genreService;
        private readonly ITagService _tagService;
        private readonly IDirectorService _directorService;
        private readonly IActorService _actorService;
        private readonly IValidator<MovieFormDTO> _movieFormDTOValidator;
        private readonly FileUpload _fileUpload;
        private readonly IMapper _mapper;

        public MovieController(
            IMovieService movieService, 
            IGenreService genreService,
            ITagService tagService,
            IDirectorService directorService,
            IActorService actorService,
            IValidator<MovieFormDTO> movieFormDTOValidator,
            FileUpload fileUpload,
            IMapper mapper
            )
        {
            _movieService = movieService;
            _genreService = genreService;
            _tagService = tagService;
            _directorService = directorService;
            _actorService = actorService;
            _movieFormDTOValidator = movieFormDTOValidator;
            _fileUpload = fileUpload;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index(int page = 1, int pageSize = 10)
        {
            if (page <= 0) page = 1;

            var actualMovies = await _movieService.GetActualsAsync();
            ViewBag.ActualMovies = actualMovies;

            var expectedMovies = await _movieService.GetExpectedAsync();

            if (expectedMovies.Count() != 0 && expectedMovies.Count() <= (page - 1) * pageSize) return BadRequest();

            return View(await expectedMovies.ToPagedListAsync(page, pageSize));
        }

        public async Task<IActionResult> Details(int id)
        {
            if (id <= 0) return BadRequest();

            try
            {
                var movie = await _movieService.GetFullMovieByIdAsync(id);
                return View(movie);
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
        }

        public async Task<IActionResult> Manage(int page = 1, int pageSize = 10)
        {
            if (page <= 0) page = 1;

            var movies = await _movieService.GetAllMoviesAsync();

            if (movies.Count() <= (page - 1) * pageSize) return BadRequest();

            return View(await movies.ToPagedListAsync(page, pageSize));
        }

        public async Task<IActionResult> Create()
        {
            await FillViewBagMovieCreateUpdate();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(MovieFormDTO movieFormDTO)
        {
            var result = _movieFormDTOValidator.Validate(movieFormDTO, m => m.IncludeRuleSets("Create"));
            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                await FillViewBagMovieCreateUpdate();
                return View(movieFormDTO);
            }

            var fileName = _fileUpload.SaveFileToWwwRoot("images/movies", movieFormDTO.ImageFile.FileName, movieFormDTO.ImageFile.OpenReadStream());
            var imagePath =  "movies/" + fileName;

            await _movieService.CreateMovieAsync(movieFormDTO, imagePath);
            TempData[WebConstants.alertSuccessKey] = "Movie created successfully";
            return RedirectToAction(nameof(Manage));
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (id <= 0) return BadRequest();

            try
            {
                var movie = await _movieService.GetMovieFormByIdAsync(id);
                await FillViewBagMovieCreateUpdate();
                return View(movie);
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(MovieFormDTO movieFormDTO)
        {
            var result = _movieFormDTOValidator.Validate(movieFormDTO, m => m.IncludeRuleSets("Edit"));
            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                await FillViewBagMovieCreateUpdate();
                return View(movieFormDTO);
            }

            string? imagePath = null;

            if (movieFormDTO.ImageFile != null)
            {
                var fileName = _fileUpload.SaveFileToWwwRoot("images/movies", movieFormDTO.ImageFile.FileName, movieFormDTO.ImageFile.OpenReadStream());
                imagePath = "movies/" + fileName;
            }
            
            await _movieService.UpdateMovieAsync(movieFormDTO, imagePath);
            TempData[WebConstants.alertSuccessKey] = "Movie updated successfully";
            return RedirectToAction(nameof(Manage));
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) return BadRequest();

            try
            {
                await _movieService.GetMovieByIdAsync(id);
                await _movieService.DeleteMovieAsync(id);
                TempData[WebConstants.alertSuccessKey] = "Movie deleted successfully";
                return RedirectToAction(nameof(Manage));
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
        }

        private async Task FillViewBagGenres()
        {
            ViewBag.Genres = (await _genreService.GetAllGenresAsync())
                .Select(g => new SelectListItem
                {
                    Value = g.Id.ToString(),
                    Text = g.Name
                })
                .ToList()
            ;
        }

        private async Task FillViewBagTags()
        {
            ViewBag.Tags = (await _tagService.GetAllTagsAsync())
                .Select(t => new SelectListItem
                {
                    Value = t.Id.ToString(),
                    Text = t.Name
                })
                .ToList()
            ;
        }

        private async Task FillViewBagDirectors()
        {
            ViewBag.Directors = (await _directorService.GetAllDirectorsAsync())
                .Select(d => new SelectListItem
                {
                    Value = d.Id.ToString(),
                    Text = d.Name
                })
                .ToList()
            ;
        }

        private async Task FillViewBagActors()
        {
            ViewBag.Actors = (await _actorService.GetAllActorsAsync())
                .Select(a => new SelectListItem
                {
                    Value = a.Id.ToString(),
                    Text = a.Name
                })
                .ToList()
            ;
        }

        private async Task FillViewBagMovieCreateUpdate()
        {
            await FillViewBagGenres();
            await FillViewBagTags();
            await FillViewBagDirectors();
            await FillViewBagActors();
        }
    }
}

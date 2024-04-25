using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using SoftServeCinema.Core.DTOs.Genres;
using SoftServeCinema.Core.Exceptions;
using SoftServeCinema.Core.Interfaces.Services;
using SoftServeCinema.MVC.Helpers;
using X.PagedList;

namespace SoftServeCinema.MVC.Controllers
{
    public class GenreController : Controller
    {
        private readonly IGenreService _genreService;
        private readonly IValidator<GenreDTO> _genreValidator;
        
        public GenreController(IGenreService genreService, IValidator<GenreDTO> genreValidator)
        {
            _genreService = genreService;
            _genreValidator = genreValidator;
        }

        public async Task<IActionResult> Index(int page = 1, int pageSize = 10)
        {
            if (page <= 0) page = 1;

            var genres = await _genreService.GetAllGenresAsync();

            if (genres.Count() <= (page - 1) * pageSize) return BadRequest();

            return View(await genres.ToPagedListAsync(page, pageSize));
        }

        public async Task<IActionResult> Details(int id)
        {
            if (id <= 0) return BadRequest();

            try
            {
                var genre = await _genreService.GetGenreWithMoviesAsync(id);
                return View(genre);
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
        }

        public async Task<IActionResult> Manage(int page = 1, int pageSize = 10)
        {
            if (page <= 0) page = 1;

            var genres = await _genreService.GetAllGenresAsync();

            if (genres.Count() <= (page - 1) * pageSize) return BadRequest();

            return View(await genres.ToPagedListAsync(page, pageSize));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(GenreDTO genreDTO)
        {
            var result = _genreValidator.Validate(genreDTO, g => g.IncludeRuleSets("Create"));
            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View(genreDTO);
            }
            await _genreService.CreateGenreAsync(genreDTO);
            TempData[WebConstants.alertSuccessKey] = "Жанр додано успішно!";
            return RedirectToAction(nameof(Manage));
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (id <= 0) return BadRequest();

            try
            {
                var genre = await _genreService.GetGenreByIdAsync(id);
                return View(genre);
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(GenreDTO genreDTO)
        {
            var result = _genreValidator.Validate(genreDTO, g => g.IncludeRuleSets("Edit"));
            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View(genreDTO);
            }
            await _genreService.UpdateGenreAsync(genreDTO);
            TempData[WebConstants.alertSuccessKey] = "Жанр оновлено успішно";
            return RedirectToAction(nameof(Manage));
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) return BadRequest();

            try
            {
                await _genreService.GetGenreByIdAsync(id);
                await _genreService.DeleteGenreAsync(id);
                TempData[WebConstants.alertSuccessKey] = "Жанр видалено успішно";
                return RedirectToAction(nameof(Manage));
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
        }
    }
}

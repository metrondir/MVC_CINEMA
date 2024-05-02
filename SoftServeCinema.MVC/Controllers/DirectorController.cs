using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SoftServeCinema.Core.DTOs.Directors;
using SoftServeCinema.Core.Exceptions;
using SoftServeCinema.Core.Interfaces.Services;
using SoftServeCinema.MVC.Helpers;
using X.PagedList;

namespace SoftServeCinema.MVC.Controllers
{
    [Authorize(Roles = "RequireAdminRole")]

    public class DirectorController : Controller
    {
        private readonly IDirectorService _directorService;
        private readonly IValidator<DirectorDTO> _directorValidator;

        public DirectorController(IDirectorService directorService, IValidator<DirectorDTO> directorValidator)
        {
            _directorService = directorService;
            _directorValidator = directorValidator;
        }

        public async Task<IActionResult> Index(int page = 1, int pageSize = 10)
        {
            if (page <= 0) page = 1;

            var directors = await _directorService.GetAllDirectorsAsync();

            if (directors.Count() <= (page - 1) * pageSize) return BadRequest();

            return View(await directors.ToPagedListAsync(page, pageSize));
        }

        public async Task<IActionResult> Details(int id)
        {
            if (id <= 0) return BadRequest();

            try
            {
                var director = await _directorService.GetDirectorWithMoviesAsync(id);
                return View(director);
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
        }

        public async Task<IActionResult> Manage(int page = 1, int pageSize = 10)
        {
            if (page <= 0) page = 1;

            var directors = await _directorService.GetAllDirectorsAsync();

            if (directors.Count() <= (page - 1) * pageSize) return BadRequest();

            return View(await directors.ToPagedListAsync(page, pageSize));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(DirectorDTO directorDTO)
        {
            var result = _directorValidator.Validate(directorDTO, a => a.IncludeRuleSets("Create"));
            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View(directorDTO);
            }
            await _directorService.CreateDirectorAsync(directorDTO);
            TempData[WebConstants.alertSuccessKey] = "Режисера додано успішно!";
            return RedirectToAction(nameof(Manage));
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (id <= 0) return BadRequest();

            try
            {
                var director = await _directorService.GetDirectorByIdAsync(id);
                return View(director);
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(DirectorDTO directorDTO)
        {
            var result = _directorValidator.Validate(directorDTO, a => a.IncludeRuleSets("Edit"));
            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View(directorDTO);
            }
            await _directorService.UpdateDirectorAsync(directorDTO);
            TempData[WebConstants.alertSuccessKey] = "Режисера оновлено успішно";
            return RedirectToAction(nameof(Manage));
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) return BadRequest();

            try
            {
                await _directorService.GetDirectorByIdAsync(id);
                await _directorService.DeleteDirectorAsync(id);
                TempData[WebConstants.alertSuccessKey] = "Режисера видалено успішно";
                return RedirectToAction(nameof(Manage));
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
        }
    }
}

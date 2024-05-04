using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SoftServeCinema.Core.DTOs.Actors;
using SoftServeCinema.Core.Exceptions;
using SoftServeCinema.Core.Interfaces.Services;
using SoftServeCinema.MVC.Helpers;
using X.PagedList;

namespace SoftServeCinema.MVC.Controllers
{
    

    public class ActorController : Controller
    {
        private readonly IActorService _actorService;
        private readonly IValidator<ActorDTO> _actorValidator;

        public ActorController(IActorService actorService, IValidator<ActorDTO> actorValidator)
        {
            _actorService = actorService;
            _actorValidator = actorValidator;
        }

        public async Task<IActionResult> Index(int page = 1, int pageSize = 10)
        {
            if (page <= 0) page = 1;

            var actors = await _actorService.GetAllActorsAsync();

            if (actors.Count() <= (page - 1) * pageSize) return BadRequest();

            return View(await actors.ToPagedListAsync(page, pageSize));
        }

        public async Task<IActionResult> Details(int id)
        {
            if (id <= 0) return BadRequest();

            try
            {
                var actor = await _actorService.GetActorWithMoviesAsync(id);
                return View(actor);
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
        }

        //[Authorize(Roles = "Admin, SuperAdmin")]
        public async Task<IActionResult> Manage(int page = 1, int pageSize = 10)
        {
            if (page <= 0) page = 1;

            var actors = await _actorService.GetAllActorsAsync();

            if (actors.Count() <= (page - 1) * pageSize) return BadRequest();

            return View(await actors.ToPagedListAsync(page, pageSize));
        }

        //[Authorize(Roles = "Admin, SuperAdmin")]
        public IActionResult Create()
        {
            return View();
        }

        //[Authorize(Roles = "Admin, SuperAdmin")]
        [HttpPost]
        public async Task<IActionResult> Create(ActorDTO actorDTO)
        {
            var result = _actorValidator.Validate(actorDTO, a => a.IncludeRuleSets("Create"));
            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View(actorDTO);
            }
            await _actorService.CreateActorAsync(actorDTO);
            TempData[WebConstants.alertSuccessKey] = "Актора додано успішно!";
            return RedirectToAction(nameof(Manage));
        }

        //[Authorize(Roles = "Admin, SuperAdmin")]
        public async Task<IActionResult> Edit(int id)
        {
            if (id <= 0) return BadRequest();

            try
            {
                var actor = await _actorService.GetActorByIdAsync(id);
                return View(actor);
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
        }

        //[Authorize(Roles = "Admin, SuperAdmin")]
        [HttpPost]
        public async Task<IActionResult> Edit(ActorDTO actorDTO)
        {
            var result = _actorValidator.Validate(actorDTO, a => a.IncludeRuleSets("Edit"));
            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View(actorDTO);
            }
            await _actorService.UpdateActorAsync(actorDTO);
            TempData[WebConstants.alertSuccessKey] = "Актора оновлено успішно";
            return RedirectToAction(nameof(Manage));
        }

        //[Authorize(Roles = "Admin, SuperAdmin")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) return BadRequest();

            try
            {
                await _actorService.GetActorByIdAsync(id);
                await _actorService.DeleteActorAsync(id);
                TempData[WebConstants.alertSuccessKey] = "Актора видалено успішно";
                return RedirectToAction(nameof(Manage));
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
        }
    }
}

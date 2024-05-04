using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SoftServeCinema.Core.DTOs.Tags;
using SoftServeCinema.Core.Exceptions;
using SoftServeCinema.Core.Interfaces.Services;
using SoftServeCinema.MVC.Helpers;
using X.PagedList;

namespace SoftServeCinema.MVC.Controllers
{

    public class TagController : Controller
    {
        private readonly ITagService _tagService;
        private readonly IValidator<TagDTO> _tagValidator;

        public TagController(ITagService tagService, IValidator<TagDTO> tagValidator)
        {
            _tagService = tagService;
            _tagValidator = tagValidator;
        }

        public async Task<IActionResult> Index(int page = 1, int pageSize = 10)
        {
            if (page <= 0) page = 1;

            var tags = await _tagService.GetAllTagsAsync();

            if (tags.Count() <= (page - 1) * pageSize) return BadRequest();

            return View(await tags.ToPagedListAsync(page, pageSize));
        }

        public async Task<IActionResult> Details(int id)
        {
            if (id <= 0) return BadRequest();

            try
            {
                var tag = await _tagService.GetTagWithMoviesAsync(id);
                return View(tag);
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

            var tags = await _tagService.GetAllTagsAsync();

            if (tags.Count() <= (page - 1) * pageSize) return BadRequest();

            return View(await tags.ToPagedListAsync(page, pageSize));
        }

        //[Authorize(Roles = "Admin, SuperAdmin")]
        public IActionResult Create()
        {
            return View();
        }

        //[Authorize(Roles = "Admin, SuperAdmin")]
        [HttpPost]
        public async Task<IActionResult> Create(TagDTO tagDTO)
        {
            var result = _tagValidator.Validate(tagDTO, a => a.IncludeRuleSets("Create"));
            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View(tagDTO);
            }
            await _tagService.CreateTagAsync(tagDTO);
            TempData[WebConstants.alertSuccessKey] = "Тег додано успішно!";
            return RedirectToAction(nameof(Manage));
        }

        //[Authorize(Roles = "Admin, SuperAdmin")]
        public async Task<IActionResult> Edit(int id)
        {
            if (id <= 0) return BadRequest();

            try
            {
                var tag = await _tagService.GetTagByIdAsync(id);
                return View(tag);
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
        }

        //[Authorize(Roles = "Admin, SuperAdmin")]
        [HttpPost]
        public async Task<IActionResult> Edit(TagDTO tagDTO)
        {
            var result = _tagValidator.Validate(tagDTO, a => a.IncludeRuleSets("Edit"));
            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View(tagDTO);
            }
            await _tagService.UpdateTagAsync(tagDTO);
            TempData[WebConstants.alertSuccessKey] = "Тег оновлено успішно";
            return RedirectToAction(nameof(Manage));
        }

        //[Authorize(Roles = "Admin, SuperAdmin")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) return BadRequest();

            try
            {
                await _tagService.GetTagByIdAsync(id);
                await _tagService.DeleteTagAsync(id);
                TempData[WebConstants.alertSuccessKey] = "Тег видалено успішно";
                return RedirectToAction(nameof(Manage));
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
        }
    }
}

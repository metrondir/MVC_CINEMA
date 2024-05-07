using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SoftServeCinema.Core.DTOs.Sessions;
using SoftServeCinema.Core.Exceptions;
using SoftServeCinema.Core.Interfaces.Services;
using SoftServeCinema.Core.Services;
using SoftServeCinema.Core.Validators;
using SoftServeCinema.MVC.Helpers;
using X.PagedList;

namespace SoftServeCinema.MVC.Controllers
{
    public class SessionController : Controller
    {
        private readonly ISessionService _sessionService;
        private readonly ITicketService _ticketService;
        private readonly IValidator<SessionFormDTO> _sessionFormDTOValidator;
        private readonly IMapper _mapper;

        public SessionController(ISessionService sessionService, ITicketService ticketService, IValidator<SessionFormDTO> sessionFormDTOValidator, IMapper mapper)
        {
            _sessionService = sessionService;
            _ticketService = ticketService;
            _sessionFormDTOValidator = sessionFormDTOValidator;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index(int page = 1, int pageSize = 10)
        {
            if (page <= 0) page = 1;

            var actualSessions = await _sessionService.GetSessionsByDay(DateTime.UtcNow);
            ViewBag.ActualSessions = actualSessions;

            var sessions = await _sessionService.GetAllSessionsAsync();

            return View(await sessions.ToPagedListAsync(page, pageSize));
        }

        public async Task<IActionResult> Details(int id)
        {
            if (id <= 0) return BadRequest();

            try
            {
                var session = await _sessionService.GetSessionFormByIdAsync(id);
                return View(session);
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
        }

        public async Task<IActionResult> Manage(int page = 1, int pageSize = 10)
        {
            if (page <= 0) page = 1;

            var sessions = await _sessionService.GetAllSessionsAsync();

            if (sessions.Count() <= (page - 1) * pageSize) return BadRequest();

            return View(await sessions.ToPagedListAsync(page, pageSize));
        }

        public async Task<IActionResult> Create()
        {
            await FillViewBagSessionCreateUpdate();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SessionFormDTO sessionFormDTO)
        {
            var result = _sessionFormDTOValidator.Validate(sessionFormDTO, s => s.IncludeRuleSets("Create"));
            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                await FillViewBagSessionCreateUpdate();
                return View(sessionFormDTO);
            }

            await _sessionService.CreateSessionAsync(sessionFormDTO);
            TempData[WebConstants.alertSuccessKey] = "Session created successfully";
            return RedirectToAction(nameof(Manage));
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (id <= 0) return BadRequest();

            try
            {
                var session = await _sessionService.GetSessionFormByIdAsync(id);
                await FillViewBagSessionCreateUpdate();
                return View(session);
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SessionFormDTO sessionFormDTO)
        {
            var result = _sessionFormDTOValidator.Validate(sessionFormDTO, s => s.IncludeRuleSets("Edit"));
            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                await FillViewBagSessionCreateUpdate();
                return View(sessionFormDTO);
            }

            await _sessionService.UpdateSessionAsync(sessionFormDTO);
            TempData[WebConstants.alertSuccessKey] = "Session updated successfully";
            return RedirectToAction(nameof(Manage));
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) return BadRequest();

            try
            {
                await _sessionService.GetSessionFormByIdAsync(id);
                await _sessionService.DeleteSessionAsync(id);
                TempData[WebConstants.alertSuccessKey] = "Session deleted successfully";
                return RedirectToAction(nameof(Manage));
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
        }

        private async Task FillViewBagTickets()
        {
            ViewBag.Tickets = (await _ticketService.GetAllTicketsAsync())
                .Select(t => new SelectListItem
                {
                    Value = t.Id.ToString(),
                    Text = "Ряд: " + t.RowNumber + " Місце: " + t.SeatNumber
                })
                .ToList();
        }

        private async Task FillViewBagSessionCreateUpdate()
        {
            await FillViewBagTickets();
        }
    }
}

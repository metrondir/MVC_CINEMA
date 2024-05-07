using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
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
        private readonly IMovieService _movieService;
        private readonly ITicketService _ticketService;
        private readonly IValidator<SessionDTO> _sessionFormDTOValidator;
        private readonly IMapper _mapper;

        public SessionController(ISessionService sessionService, IMovieService movieService, ITicketService ticketService, IValidator<SessionDTO> sessionFormDTOValidator, IMapper mapper)
        {
            _sessionService = sessionService;
            _movieService = movieService;
            _ticketService = ticketService;
            _sessionFormDTOValidator = sessionFormDTOValidator;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index(int page = 1, int pageSize = 10)
        {
            if (page <= 0) page = 1;

            var sessions = await _sessionService.GetAllSessionsAsync();

            var sessionViewModels = sessions.Select(s => new SessionViewModelDTO
            {
                Id = s.Id,
                MovieId = s.MovieId,
                StartDate = s.StartDate,
                TicketsCount = _ticketService.GetAvailableAsync().Result.Count,
                MovieTitle = _movieService.GetMovieByIdAsync(s.MovieId).Result.Title
            });
            
            return View(await sessionViewModels.ToPagedListAsync(page, pageSize));
        }

        public async Task<IActionResult> Details(int id)
        {
            if (id <= 0) return BadRequest();

            try
            {
                var session = await _sessionService.GetSessionFormByIdAsync(id);

                var sessionDetails =  new SessionDetailsDTO
                {
                    Id = session.Id,
                    MovieId = session.MovieId,
                    StartDate = session.StartDate,
                    MovieTitle = _movieService.GetMovieByIdAsync(session.MovieId).Result.Title,
                    MovieImagePath = _movieService.GetMovieByIdAsync(session.MovieId).Result.ImagePath,
                    BasicPrice = session.BasicPrice,
                    VipPrice = session.VipPrice
                };

                return View(sessionDetails);
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

            var sessions = await _sessionService.GetAllSessionsAsync();

            var sessionViewModels = sessions.Select(s => new SessionViewModelDTO
            {
                Id = s.Id,
                MovieId = s.MovieId,
                StartDate = s.StartDate,
                TicketsCount = _ticketService.GetAvailableAsync().Result.Count,
                MovieTitle = _movieService.GetMovieByIdAsync(s.MovieId).Result.Title
            });

            if (sessionViewModels.Count() <= (page - 1) * pageSize) return BadRequest();

            return View(await sessionViewModels.ToPagedListAsync(page, pageSize));
        }

        //[Authorize(Roles = "Admin, SuperAdmin")]
        public async Task<IActionResult> Create()
        {
            await FillViewBagSessionCreateUpdate();
            return View();
        }

        //[Authorize(Roles = "Admin, SuperAdmin")]
        [HttpPost]
        public async Task<IActionResult> Create(SessionDTO sessionFormDTO)
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

        //[Authorize(Roles = "Admin, SuperAdmin")]
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

        //[Authorize(Roles = "Admin, SuperAdmin")]
        [HttpPost]
        public async Task<IActionResult> Edit(SessionDTO sessionFormDTO)
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

        //[Authorize(Roles = "Admin, SuperAdmin")]
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

        private async Task FillViewBagMovies()
        {
            ViewBag.Movies = (await _movieService.GetAllMoviesAsync())
                .Select(m => new SelectListItem
                {
                    Value = m.Id.ToString(),
                    Text = m.Title
                })
                .ToList();
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
            await FillViewBagMovies();
            await FillViewBagTickets();
        }
    }
}

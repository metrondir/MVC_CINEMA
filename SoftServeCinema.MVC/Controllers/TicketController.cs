using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SoftServeCinema.Core.DTOs.Tickets;
using SoftServeCinema.Core.Exceptions;
using SoftServeCinema.Core.Interfaces.Services;
using SoftServeCinema.MVC.Helpers;
using System.IdentityModel.Tokens.Jwt;
using X.PagedList;

namespace SoftServeCinema.MVC.Controllers
{
    public class TicketController : Controller
    {
        private readonly ITicketService _ticketService;
        private readonly ISessionService _sessionService;

        public TicketController(ITicketService ticketService, ISessionService sessionService)
        {
            _ticketService = ticketService;
            _sessionService = sessionService;
        }

        public async Task<IActionResult> Index(int page = 1, int pageSize = 10)
        {
            if (page <= 0) page = 1;

            var ticket = await _ticketService.GetAllTicketsAsync();

            if (ticket.Count() <= (page - 1) * pageSize) return BadRequest();

            return View(await ticket.ToPagedListAsync(page, pageSize));
        }

        public async Task<IActionResult> Details(int id)
        {
            if (id <= 0) return BadRequest();

            try
            {
                var ticket = await _ticketService.GetTicketByIdAsync(id);
                return View(ticket);
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

            var ticket = await _ticketService.GetAllTicketsAsync();

            if (ticket.Count() <= (page - 1) * pageSize) return BadRequest();

            return View(await ticket.ToPagedListAsync(page, pageSize));
        }

        //[Authorize(Roles = "Admin, SuperAdmin")]
        public async Task<IActionResult> Create()
        {
            await FillViewBagTicketCreateUpdate();
            return View();
        }

        //[Authorize(Roles = "Admin, SuperAdmin")]
        [HttpPost]
        public async Task<IActionResult> Create(TicketDTO ticketDTO)
        {
            await FillViewBagTicketCreateUpdate();
            await _ticketService.CreateTicketAsync(ticketDTO);
            TempData[WebConstants.alertSuccessKey] = "Ticket created successfully";
            return RedirectToAction(nameof(Manage));
        }

        //[Authorize(Roles = "Admin, SuperAdmin")]
        public async Task<IActionResult> Edit(int id)
        {
            if (id <= 0) return BadRequest();

            try
            {
                var ticket = await _ticketService.GetTicketByIdAsync(id);
                await FillViewBagTicketCreateUpdate();
                return View(ticket);
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
        }

        //[Authorize(Roles = "Admin, SuperAdmin")]
        [HttpPost]
        public async Task<IActionResult> Edit(TicketDTO ticketDTO)
        {
            await FillViewBagTicketCreateUpdate();
            await _ticketService.UpdateTicketAsync(ticketDTO);
            TempData[WebConstants.alertSuccessKey] = "Ticket updated successfully";
            return RedirectToAction(nameof(Manage));
        }

        //[Authorize(Roles = "Admin, SuperAdmin")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) return BadRequest();

            try
            {
                await _ticketService.GetTicketByIdAsync(id);
                await _ticketService.DeleteTicketAsync(id);
                TempData[WebConstants.alertSuccessKey] = "Ticket deleted successfully";
                return RedirectToAction(nameof(Manage));
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
        }
        //[Authorize]
        public async Task<IActionResult> Reserved(int page = 1, int pageSize = 10)
        {

            if (page <= 0) page = 1;
            var userId = new JwtSecurityTokenHandler().ReadJwtToken(HttpContext.Session.GetString("accessToken")).Claims.FirstOrDefault(c => c.Type == "nameid").Value;

            var tickets = await _ticketService.GetReservationByUserIdAsync(userId);
            if (tickets.Count() <= (page - 1) * pageSize && tickets.Count() != 0) return BadRequest();

            return View(await tickets.ToPagedListAsync(page, pageSize));

        }
        //[Authorize]

        public async Task <IActionResult>Cancel (int id)
        {
            if (id <= 0) return BadRequest();
           await _ticketService.CancelReservationById(id);
            TempData[WebConstants.alertSuccessKey] = "Ticket canceled successfully";
            return RedirectToAction(nameof(Reserved));
        }
        public async Task<IActionResult> Buy(int[] ticketIds)
        {
            await _ticketService.BuyTicketsByIdsAsync(ticketIds);

            TempData[WebConstants.alertSuccessKey] = "Tickets bought successfully";
            return RedirectToAction(nameof(Bought));
        }
        //[Authorize]
        public async Task<IActionResult> Bought(int page = 1, int pageSize = 10)
        {

            if (page <= 0) page = 1;
            var userId = new JwtSecurityTokenHandler().ReadJwtToken(HttpContext.Session.GetString("accessToken")).Claims.FirstOrDefault(c => c.Type == "nameid").Value;

            var tickets = await _ticketService.GetBoughtByUserIdAsync(userId);

            if (tickets.Count() <= (page - 1) * pageSize && tickets.Count() != 0) return BadRequest();

            return View(await tickets.ToPagedListAsync(page, pageSize));

        }
        private async Task FillViewBagSessions()
        {
            ViewBag.Sessions = (await _sessionService.GetAllSessionsAsync())
                .Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = "MovieId: " + s.MovieId.ToString()
                })
                .ToList()
            ;
        }

        private async Task FillViewBagTicketCreateUpdate()
        {
            await FillViewBagSessions();
        }
    }
}

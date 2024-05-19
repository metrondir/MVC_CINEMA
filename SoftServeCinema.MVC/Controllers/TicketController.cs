using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
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
            var userId = new JwtSecurityTokenHandler().ReadJwtToken(HttpContext.Session.GetString("accessToken")).Claims.FirstOrDefault(c => c.Type == "nameid").Value;

            var ticketsReserved = await _ticketService.GetReservationByUserIdAsync(userId);
            var ticketBought = await _ticketService.GetBoughtByUserIdAsync(userId);
            ViewBag.ReservedTickets = ticketsReserved;
            ViewBag.ReservedTicketsJsonIds =JsonConvert.SerializeObject(ticketsReserved.Select(s => s.Id));
            if (ticketBought.Count() <= (page - 1) * pageSize && ticketBought.Count() != 0) return BadRequest();

            return View(await ticketBought.ToPagedListAsync(page, pageSize));
        }

        [Authorize]
        public async Task <IActionResult>Cancel (int id)
        {
            if (id <= 0) return BadRequest();
           await _ticketService.CancelReservationById(id);
            TempData[WebConstants.alertSuccessKey] = "Ticket canceled successfully";
            return RedirectToAction(nameof(Index));
        }


    }
}

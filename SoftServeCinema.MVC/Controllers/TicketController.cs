using Microsoft.AspNetCore.Mvc;
using SoftServeCinema.Core.DTOs.Tickets;
using SoftServeCinema.Core.Exceptions;
using SoftServeCinema.Core.Interfaces.Services;
using SoftServeCinema.MVC.Helpers;
using X.PagedList;

namespace SoftServeCinema.MVC.Controllers
{
    public class TicketController : Controller
    {
        private readonly ITicketService _ticketService;

        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
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

        public async Task<IActionResult> Manage(int page = 1, int pageSize = 10)
        {
            if (page <= 0) page = 1;

            var ticket = await _ticketService.GetAllTicketsAsync();

            if (ticket.Count() <= (page - 1) * pageSize) return BadRequest();

            return View(await ticket.ToPagedListAsync(page, pageSize));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TicketDTO ticketDTO)
        {
            await _ticketService.CreateTicketAsync(ticketDTO);
            TempData[WebConstants.alertSuccessKey] = "Ticket created successfully";
            return RedirectToAction(nameof(Manage));
        }

        public async Task<IActionResult> Edit(int id)
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

        [HttpPost]
        public async Task<IActionResult> Edit(TicketDTO ticketDTO)
        {
            await _ticketService.UpdateTicketAsync(ticketDTO);
            TempData[WebConstants.alertSuccessKey] = "Ticket updated successfully";
            return RedirectToAction(nameof(Manage));
        }

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
    }
}

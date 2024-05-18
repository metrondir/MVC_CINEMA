using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using SoftServeCinema.Core.DTOs.Directors;
using SoftServeCinema.Core.Interfaces.Services;
using System;
using System.IdentityModel.Tokens.Jwt;

namespace SoftServeCinema.MVC.Controllers
{
    //[Authorize]
    public class ReservationController : ControllerBase
    {
        private readonly ITicketService _ticketService;

       
        public ReservationController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ReservationTickets([FromForm] string ticketIdsJson)
        {
            var ticketIds = JsonConvert.DeserializeObject<int[]>(ticketIdsJson);
            if (ticketIds == null) return BadRequest();
            var result = await _ticketService.CheckTickets(ticketIds);

            var userId = new JwtSecurityTokenHandler().ReadJwtToken(HttpContext.Session.GetString("accessToken")).Claims.FirstOrDefault(c => c.Type == "nameid").Value;
            if (!result)
                return BadRequest();
            await _ticketService.ReserveTicketsByIds(ticketIds, userId);
            return RedirectToAction("Index", "Home");



        }
    }
}

using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using SoftServeCinema.Core.DTOs.Checkout;
using Stripe.Checkout;
using SoftServeCinema.Core.DTOs.Tickets;
using SoftServeCinema.MVC.Helpers;
using SoftServeCinema.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using Stripe;
using System.Collections.Generic;

namespace SoftServeCinema.MVC.Controllers
{
    public class CheckoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        private readonly ITicketService _ticketService;

        private readonly IConfiguration _configuration;
        
        private static string s_wasmClientURL = string.Empty;

        public CheckoutController(IConfiguration configuration, ITicketService ticketService)
        {
            _configuration = configuration;
            _ticketService = ticketService;
        }

        public async Task<IActionResult> Success()
        {

            return View();
        }
        public async Task<IActionResult> Failed()
        {

            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> CheckoutOrder(int[] ticketIds, [FromServices] IServiceProvider sp)
        {
            var referer = Request.Headers.Referer;
            s_wasmClientURL = referer[0];
            var userId = new JwtSecurityTokenHandler().ReadJwtToken(HttpContext.Session.GetString("accessToken")).Claims.FirstOrDefault(c => c.Type == "nameid").Value;
            //await _ticketService.ReserveTicketsByIds(ticketIds,userId);
            var tickets = await _ticketService.GetReservationByUserIdAsync(userId);
            var server = sp.GetRequiredService<IServer>();

            var serverAddressesFeature = server.Features.Get<IServerAddressesFeature>();

            string? thisApiUrl = null;

            if (serverAddressesFeature is not null)
            {
                thisApiUrl = serverAddressesFeature.Addresses.FirstOrDefault();
            }

            if (thisApiUrl is not null)
            {
                var Url = await CheckOut(tickets, thisApiUrl);

                return Redirect(Url);
            }
            else
            {
                return StatusCode(500);
            }
        }

        [NonAction]
        public async Task<string> CheckOut(List<TicketDetailDTO> tickets, string thisApiUrl)
        {
            if (tickets == null || tickets.Count == 0)
            {
                throw new ArgumentException("Ticket list cannot be null or empty", nameof(tickets));
            }
            var ticketIds = string.Join(",", tickets.Select(t => t.Id));

            var lineItems = new List<SessionLineItemOptions>();
            foreach (var ticket in tickets)
            {
                long unitAmount = (long)(ticket.RowNumber == 6 ? ticket.Session.VipPrice * 100 : ticket.Session.BasicPrice * 100);
                lineItems.Add(new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        UnitAmount = unitAmount,
                        Currency = "UAH",
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = ticket.Session.MovieTitle,
                            Description = $"{ticket.RowNumber} row \n {ticket.SeatNumber} seat \t {(ticket.RowNumber == 6 ? "VIP" : "Standart") }",
                            
                        },
                    },
                    Quantity = 1
                });
            }

            var options = new SessionCreateOptions
            {
                SuccessUrl = $"{thisApiUrl}/checkout/success?sessionId={{CHECKOUT_SESSION_ID}}",
                CancelUrl = $"{thisApiUrl}/checkout/failed",
                PaymentMethodTypes = new List<string> { "card" },
                LineItems = lineItems,
                Mode = "payment",
                Metadata = new Dictionary <string, string>
            {
                { "ticketIds", ticketIds }
            }
        };

                var service = new SessionService();
      
                var session = await service.CreateAsync(options);
                return session.Url;
           
        }



        [HttpGet]
        public async Task<IActionResult> CheckoutSuccess( int[] ticketIds)
        {

            await _ticketService.BuyTicketsByIdsAsync(ticketIds);

            TempData[WebConstants.alertSuccessKey] = "Tickets bought successfully";


            return RedirectToAction("Bought","Ticket");
        }
    }
}



using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SoftServeCinema.Core.DTOs.Payment;
using SoftServeCinema.Core.DTOs.Tickets;
using SoftServeCinema.Core.DTOs.Users;
using SoftServeCinema.Core.Interfaces.Services;
using SoftServeCinema.MVC.Helpers;
using Stripe;
using Stripe.Checkout;
using System.Net.Http.Headers;
using System.Text;

namespace SoftServeCinema.MVC.Controllers
{
    public class WebhookController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        private readonly ITicketService _ticketService;
        private readonly IConfiguration _configuration;
        private readonly IPdfService _pdfService;
        private readonly IQRCodeService _qrCodeService;
        private readonly IPaymentService _paymentService;

        public WebhookController(ITicketService ticketService, IConfiguration configuration,IPdfService pdfService,IQRCodeService qRCodeService,IPaymentService paymentService)
        {
            _ticketService = ticketService;
            _configuration = configuration;
            _qrCodeService = qRCodeService;
            _pdfService = pdfService;
            _paymentService = paymentService;
        }

        public async Task<IActionResult> Stripe()
        {
            var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();
            Event stripeEvent;

                stripeEvent = EventUtility.ConstructEvent(
                    json,
                    Request.Headers["Stripe-Signature"],
                    _configuration["Stripe:WebHookSecret"],
                    throwOnApiVersionMismatch: false 
                );

            if (stripeEvent.Type == Events.CheckoutSessionCompleted)
            {
                var session = stripeEvent.Data.Object as Session;
                var ticketIds = session.Metadata["ticketIds"].Split(',').Select(int.Parse).ToArray();

                await _ticketService.BuyTicketsByIdsAsync(ticketIds);

                await GenerateMailToCustomerAndCreatePayment(session, ticketIds);

            }

            return Ok();
        }
        private async Task<IActionResult> GenerateMailToCustomerAndCreatePayment(Session session, int[] ticketIds)
        {
            var customerEmail = session.CustomerDetails.Email;
            var emailDTO = new EmailDTO
            {
                To = customerEmail,
                Subject = "Tickets",
            };
            var tickets = await _ticketService.GetTicketsDetailWithUserAsync(ticketIds);
            byte[] pdf = await _pdfService.GeneratePdf(tickets);
            byte[] qrCode = await _qrCodeService.GenerateQRCode(tickets);
            var url = WebConstants.ngrok + "/api/User/send-tickets";
            using (var httpClient = new HttpClient())
            {
                using (var multipartContent = new MultipartFormDataContent())
                {
                    // Attach PDF
                    var pdfContent = new ByteArrayContent(pdf);
                    pdfContent.Headers.ContentType = MediaTypeHeaderValue.Parse("application/pdf");
                    multipartContent.Add(pdfContent, "pdf", "tickets.pdf");

                    // Attach QR code
                    var qrCodeContent = new ByteArrayContent(qrCode);
                    qrCodeContent.Headers.ContentType = MediaTypeHeaderValue.Parse("image/png");
                    multipartContent.Add(qrCodeContent, "qrCode", "qrCode.png");

                    // Add other email data
                    var jsonDataEmail = JsonConvert.SerializeObject(emailDTO.To);
                    multipartContent.Add(new StringContent(jsonDataEmail), "To");

                    var jsonData = JsonConvert.SerializeObject(emailDTO.Subject);
                    multipartContent.Add(new StringContent(jsonData), "Subject");

                    var response = await httpClient.PostAsync(url, multipartContent);
                    if (response.IsSuccessStatusCode)
                    {
                        var payment = new PaymentDTO
                        {
                            TotalAmount = (decimal)(session.AmountTotal / 100),
                            PaymentDate = DateTime.UtcNow,

                            UserId = tickets.First().UserId

                        };
                        await _paymentService.CreatePaymentAsync(payment);
                    }
                    return BadRequest();
                }

            }
        }

    
    }
}

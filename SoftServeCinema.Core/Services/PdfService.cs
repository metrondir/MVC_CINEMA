using DinkToPdf;
using DinkToPdf.Contracts;
using SoftServeCinema.Core.DTOs.Tickets;
using SoftServeCinema.Core.Interfaces.Services;
using RestSharp;

using RestSharp.Authenticators;






namespace SoftServeCinema.Core.Services
{
    public class PdfService : IPdfService
    {
        private readonly IConverter _converter;
        public PdfService(IConverter converter)
        {
            _converter = converter;
        }


        public async Task<byte[]> GeneratePdf(List<TicketDetailWithUserDTO> tickets)
        {

            var htmlContent = await GenerateHtmlContent(tickets);

            var options = new RestClientOptions("https://api.pdfshift.io/v3/convert/pdf")
            {
                Authenticator = new HttpBasicAuthenticator("api", "sk_77285b19a47a64dfc1a245e20dc68cc5ba33f7f2")
            };

            var client = new RestClient(options);

            var request = new RestRequest
            {
                Method = Method.Post
            };

            var json = new
            {
                source = htmlContent,
            };

            request.AddJsonBody(json);

            var response = await client.ExecutePostAsync(request);

            if (!response.IsSuccessful)
            {
                throw new Exception($"PDF generation failed: {response.ErrorMessage}");
            }

            return response.RawBytes;


        }


        private async Task<string> GenerateHtmlContent(List<TicketDetailWithUserDTO> tickets)
        {
            var html = @"
    <html>
    <head>
        <style>
            body { font-family: Arial, sans-serif; background-color: #f4f4f9; margin: 0; padding: 20px; }
            h1 { text-align: center; color: #333; }
            table { width: 100%; border-collapse: collapse; margin: 20px 0; }
            table th, table td { border: 1px solid #ddd; padding: 8px; }
            table th { background-color: #4CAF50; color: white; }
            table tr:nth-child(even) { background-color: #f2f2f2; }
            table tr:hover { background-color: #ddd; }
            table td { text-align: center; }
            .ticket-id { font-weight: bold; }
            .movie-title { font-style: italic; }
            .start-date { font-weight: bold; }
        </style>
    </head>
    <body>
        <h1>Reserved Tickets</h1>
        <table>
            <thead>
                <tr>
                    <th>Movie</th>
                    <th>Start Date</th>
                    <th>Seat</th>
                    <th>Price</th>
                </tr>
            </thead>
            <tbody>";

            foreach (var ticket in tickets)
            {
                var price = ticket.RowNumber == 6 ? ticket.Session.VipPrice : ticket.Session.BasicPrice;
                var formattedStartDate = ticket.Session.StartDate.ToString("dd ddd HH:mm");
                html += $@"
                    <tr>
                        <td class='movie-title'>{ticket.Session.MovieTitle}</td>
                        <td class='start-date'>{formattedStartDate}</td>
                        <td>Row: {ticket.RowNumber}, Seat: {ticket.SeatNumber}</td>
                        <td>{price} UAH</td>
                    </tr>";
            }


            html += @"
            </tbody>
        </table>
    </body>
    </html>";

            return html;
        }


    }
}






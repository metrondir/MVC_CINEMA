using QRCoder;
using SoftServeCinema.Core.DTOs.Tickets;
using SoftServeCinema.Core.Interfaces.Services;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

public class QRCodeService : IQRCodeService
{
    public async Task<byte[]> GenerateQRCode(string text)
    {
        using (var qrGenerator = new QRCodeGenerator())
        {
            var qrCodeData = qrGenerator.CreateQrCode(text, QRCodeGenerator.ECCLevel.Q);
            var qrCode = new QRCode(qrCodeData);
            using (var bitmap = qrCode.GetGraphic(20, Color.Black, Color.White, true))
            {
                using (var stream = new MemoryStream())
                {
                    bitmap.Save(stream, ImageFormat.Png);
                    return stream.ToArray();
                }
            }
        }
    }

    public async Task<byte[]> GenerateQRCode(int[] ids)
    {
        string idsString = string.Join(",", ids);

        using (var qrGenerator = new QRCodeGenerator())
        {
            var qrCodeData = qrGenerator.CreateQrCode(idsString, QRCodeGenerator.ECCLevel.Q);
            var qrCode = new QRCode(qrCodeData);
            using (var bitmap = qrCode.GetGraphic(20, Color.Black, Color.White, true))
            {
                using (var stream = new MemoryStream())
                {
                    bitmap.Save(stream, ImageFormat.Png);
                    return stream.ToArray();
                }
            }
        }
    }
    public async Task<byte[]> GenerateQRCode(List<TicketDetailWithUserDTO> ticketDetails)
    {
        using (var qrGenerator = new QRCodeGenerator())
        {
            using (var hmac = new HMACSHA256())
            {
                var userIdBytes = Encoding.UTF8.GetBytes(string.Join(",", ticketDetails.Select(ticket => ticket.UserId.ToString())));
                var key = hmac.ComputeHash(userIdBytes);
                var qrCodeDataString = string.Join(";", ticketDetails.Select(ticket =>
                {
                    var rowNumber = ticket.RowNumber.ToString() != null ? $"RowNumber:{ticket.RowNumber}" : "RowNumber:Unknown";
                    var seatNumber = ticket.SeatNumber.ToString() != null ? $"SeatNumber:{ticket.SeatNumber}" : "SeatNumber:Unknown";
                    var firstName = ticket.User?.FirstName ?? "FirstName:Unknown";
                    var lastName = ticket.User?.LastName ?? "LastName:Unknown";

                    return $"{rowNumber},{seatNumber},{firstName},{lastName}";
                }));

                var qrCodeData = qrGenerator.CreateQrCode($"{qrCodeDataString},Key:{Convert.ToBase64String(key)}", QRCodeGenerator.ECCLevel.Q);
                var qrCode = new QRCode(qrCodeData);
                using (var bitmap = qrCode.GetGraphic(20, Color.Black, Color.White, true))
                {
                    using (var stream = new MemoryStream())
                    {
                        bitmap.Save(stream, ImageFormat.Png);
                        return stream.ToArray();
                    }
                }
            }
        }
    



}
}

using QRCoder;
using SoftServeCinema.Core.DTOs.Tickets;
using SoftServeCinema.Core.Interfaces.Services;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;


namespace SoftServeCinema.Core.Interfaces.Services
{
    public interface IQRCodeService 
    {
        Task <byte[]> GenerateQRCode(string text);
        Task<byte[]> GenerateQRCode(int[] ids);
        Task<byte[]> GenerateQRCode(List<TicketDetailWithUserDTO> ticketDetailWithUserDTOs);
    }
}

using SoftServeCinema.Core.DTOs.Tickets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftServeCinema.Core.Interfaces.Services
{
    public interface IPdfService
    {
        Task <byte[]> GeneratePdf(List <TicketDetailWithUserDTO> tickets);
    }
}

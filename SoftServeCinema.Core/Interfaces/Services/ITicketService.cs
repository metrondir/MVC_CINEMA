using SoftServeCinema.Core.DTOs.Tickets;

namespace SoftServeCinema.Core.Interfaces.Services
{
    public interface ITicketService
    {
        Task<List<TicketDTO>> GetAvailableAsync();
        Task<List<TicketDTO>> GetAllTicketsAsync();
        Task<List<TicketDTO>> GetTicketsByIdsAsync(ICollection<int> ticketIds);
        Task<TicketDTO> GetTicketByIdAsync(int ticketId);
        Task CreateTicketAsync(TicketDTO ticketDTO);
        Task UpdateTicketAsync(TicketDTO ticketDTO);
        Task DeleteTicketAsync(int ticketId);
    }
}

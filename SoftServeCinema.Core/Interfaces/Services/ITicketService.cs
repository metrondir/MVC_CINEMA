using SoftServeCinema.Core.DTOs.Tickets;

namespace SoftServeCinema.Core.Interfaces.Services
{
    public interface ITicketService
    {
        Task<List<TicketDTO>> GetAvailableAsync();
        Task<List<TicketDTO>> GetAllTicketsAsync();
        Task<List<TicketDTO>> GetTicketsByIdsAsync(ICollection<int> ticketIds);
        Task<List<TicketDetailDTO>> GetTicketsDetailAsync(int[] ticketsIds);
        Task<bool> CheckTickets(int[] ticketIds);
        Task CancelReservationById(int ticketId);
        Task BuyTicketsByIdsAsync(int[] ticketIds);
        Task <List<TicketDetailWithUserDTO>> GetTicketsDetailWithUserAsync(int[] ticketsIds);
        Task<List<TicketDetailDTO>> GetReservationByUserIdAsync(string userId);

        Task<List<TicketDetailDTO>> GetBoughtByUserIdAsync(string userId);


        Task ReserveTicketsByIds(int[] ticketIds,string userId);
        Task<TicketDTO> GetTicketByIdAsync(int ticketId);
        Task CreateTicketAsync(TicketDTO ticketDTO);
        Task UpdateTicketAsync(TicketDTO ticketDTO);
        Task DeleteTicketAsync(int ticketId);
    }
}

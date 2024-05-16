using AutoMapper;
using Microsoft.AspNetCore.Http;
using SoftServeCinema.Core.DTOs.Tickets;
using SoftServeCinema.Core.Entities;
using SoftServeCinema.Core.Entities.Specifications;
using SoftServeCinema.Core.Exceptions;
using SoftServeCinema.Core.Interfaces;
using SoftServeCinema.Core.Interfaces.Services;
using System.Net.Sockets;

namespace SoftServeCinema.Core.Services
{
    public class TicketService : ITicketService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<TicketEntity> _ticketRepository;

        public TicketService(IMapper mapper, IRepository<TicketEntity> ticketRepository)
        {
            _mapper = mapper;
            _ticketRepository = ticketRepository;
        }

        public async Task<List<TicketDTO>> GetAvailableAsync()
        {
            await this.UpdateReservation();
            var result = await _ticketRepository.GetListBySpecAsync(new TicketsSpecifications.GetAvailable());
            return _mapper.Map<List<TicketDTO>>(result);
        }
        public async Task<List<TicketDetailDTO>> GetReservationByUserIdAsync(string userId)
        {
            await this.UpdateReservation();
            var result = await _ticketRepository.GetListBySpecAsync(new TicketsSpecifications.GetReservedByUserId(userId));
            return _mapper.Map<List<TicketDetailDTO>>(result);
        }
        public async Task<List<TicketDetailDTO>> GetBoughtByUserIdAsync(string userId)
        {
            await this.UpdateReservation();
            var result = await _ticketRepository.GetListBySpecAsync(new TicketsSpecifications.GetBoughtByUserId(userId));
            return _mapper.Map<List<TicketDetailDTO>>(result);
        }

        public async Task<List<TicketDTO>> GetAllTicketsAsync()
        {
            var result = await _ticketRepository.GetAllAsync();
            return _mapper.Map<List<TicketDTO>>(result);
        }

        public async Task<List<TicketDTO>> GetTicketsByIdsAsync(ICollection<int> ticketIds)
        {
            var result = await _ticketRepository.GetListBySpecAsync(new TicketsSpecifications.GetByIds(ticketIds));
            return _mapper.Map<List<TicketDTO>>(result);
        }

        public async Task<TicketDTO> GetTicketByIdAsync(int ticketId)
        {
            var ticket = (await _ticketRepository.GetByIdAsync(ticketId)) ?? throw new EntityNotFoundException();
            return _mapper.Map<TicketDTO>(ticket);
        }

        public async Task CreateTicketAsync(TicketDTO ticketDTO)
        {
            var ticket = _mapper.Map<TicketEntity>(ticketDTO);
            await _ticketRepository.InsertAsync(ticket);
            await _ticketRepository.SaveAsync();
        }

        public async Task UpdateTicketAsync(TicketDTO ticketDTO)
        {
            var ticket = _mapper.Map<TicketEntity>(ticketDTO);
            _ticketRepository.Update(ticket);
            await _ticketRepository.SaveAsync();
        }

        public async Task CancelReservationById(int ticketId)
        {
            
            var ticket = await this.GetTicketByIdAsync(ticketId);
            _ticketRepository.CrearTracker();
            ticket.UserId = null;
            ticket.Status = "Available";
            await this.UpdateTicketAsync(ticket);
        }
        public async Task BuyTicketsByIdsAsync(int[] ticketIds)
        {
            var tickets = await this.GetTicketsByIdsAsync(ticketIds);
            _ticketRepository.CrearTracker();
            foreach(var ticket in tickets)
            {
                ticket.Status = "Bought";
                ticket.ReservationDate = DateTime.UtcNow;
                _ticketRepository.Update(_mapper.Map<TicketEntity>(ticket));
            }
            await _ticketRepository.SaveAsync();
        }
        public async Task UpdateReservation()
        {
            var tickets = await this.GetAllTicketsAsync();
            _ticketRepository.CrearTracker();
            foreach (var ticket in tickets)
            {
                if ((DateTime.UtcNow - ticket.ReservationDate).TotalMinutes > 15 && ticket.Status == "Reservation")
                {
                    ticket.Status = "Available";
                    ticket.UserId = null;
                    _ticketRepository.Update(_mapper.Map<TicketEntity>(ticket));
                 
                }
            }
           
            await _ticketRepository.SaveAsync();
           
        }

        public async Task ReserveTicketsByIds(int[] ticketIds, string userId)
        {
            
            var tickets = await this.GetTicketsByIdsAsync(ticketIds);
            _ticketRepository.CrearTracker();
            foreach (var ticket in tickets)
            {
                    ticket.Status = "Reservation";
                    ticket.ReservationDate = DateTime.UtcNow;
                    ticket.UserId = Guid.Parse(userId);
                    _ticketRepository.Update(_mapper.Map<TicketEntity>(ticket));
            }

            await _ticketRepository.SaveAsync();
        }
        public async Task<bool> CheckTickets(int[] ticketIds)
        {
            var tickets = await this.GetTicketsByIdsAsync(ticketIds);
            foreach (var ticket in tickets)
            {
                if (ticket.Status != "Available")
                    return false;
            }
            return true;
        }

        public async Task DeleteTicketAsync(int ticketId)
        {
            _ticketRepository.Delete(ticketId);
            await _ticketRepository.SaveAsync();
        }

      
    }
}

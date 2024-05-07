using AutoMapper;
using SoftServeCinema.Core.DTOs.Tickets;
using SoftServeCinema.Core.Entities;
using SoftServeCinema.Core.Entities.Specifications;
using SoftServeCinema.Core.Exceptions;
using SoftServeCinema.Core.Interfaces;
using SoftServeCinema.Core.Interfaces.Services;

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
            var result = await _ticketRepository.GetListBySpecAsync(new TicketsSpecifications.GetAvailable());
            return _mapper.Map<List<TicketDTO>>(result);
        }

        public async Task<List<TicketDTO>> GetAllTicketsAsync()
        {
            var result = await _ticketRepository.GetAllAsync();
            return _mapper.Map<List<TicketDTO>>(result);
        }

        public async Task<List<TicketDTO>> GetTicketByIdsAsync(ICollection<int> ticketIds)
        {
            var result = await _ticketRepository.GetListBySpecAsync(new TicketsSpecifications.GetByIds(ticketIds));
            return _mapper.Map<List<TicketDTO>>(result);
        }

        public async Task<TicketDTO> GetTicketByIdAsync(int ticketId)
        {
            var ticket = (await _ticketRepository.GetByIdAsync(ticketId)) ?? throw new EntityNotFoundException();
            return _mapper.Map<TicketDTO>(ticket);
        }

        public Task<bool> IsTicketUniqueAsync(int ticketId)
        {
            // realisation
            throw new NotImplementedException();
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

        public async Task DeleteTicketAsync(int ticketId)
        {
            _ticketRepository.Delete(ticketId);
            await _ticketRepository.SaveAsync();
        }
    }
}

using AutoMapper;
using SoftServeCinema.Core.DTOs.Sessions;
using SoftServeCinema.Core.Entities;
using SoftServeCinema.Core.Entities.Specifications;
using SoftServeCinema.Core.Exceptions;
using SoftServeCinema.Core.Interfaces;
using SoftServeCinema.Core.Interfaces.Services;

namespace SoftServeCinema.Core.Services
{
    public class SessionService : ISessionService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<SessionEntity> _sessionRepository;
        private readonly IRepository<TicketEntity> _ticketRepository;

        public SessionService(IMapper mapper, IRepository<SessionEntity> sessionRepository, IRepository<TicketEntity> ticketRepository)
        {
            _mapper = mapper;
            _sessionRepository = sessionRepository;
            _ticketRepository = ticketRepository;
        }

        public async Task<List<SessionFormDTO>> GetAllSessionsAsync()
        {
            var result = await _sessionRepository.GetAllAsync();
            return _mapper.Map<List<SessionFormDTO>>(result);
        }

        public async Task<List<SessionFormDTO>> GetSessionsByDay(DateTime dateTime)
        {
            var result = await _sessionRepository.GetListBySpecAsync(new SessionsSpecifications.GetByStartDateDay(dateTime));
            return _mapper.Map<List<SessionFormDTO>>(result);
        }

        public async Task<SessionFormDTO> GetSessionFormByIdAsync(int sessionId)
        {
            var session = await _sessionRepository.GetFirstBySpecAsync(new SessionsSpecifications.GetByIdForForm(sessionId));
            return _mapper.Map<SessionFormDTO>(session);
        }

        public async Task<bool> IsSessionUniqueAsync(DateTime startDateTime)
        {
            try
            {
                await _sessionRepository.GetFirstBySpecAsync(new SessionsSpecifications.GetByStartDateTime(startDateTime));
                return false;
            }
            catch (EntityNotFoundException)
            {
                return true;
            }
        }

        public async Task CreateSessionAsync(SessionFormDTO sessionFormDTO)
        {
            var session = _mapper.Map<SessionEntity>(sessionFormDTO);
            session.Tickets = (ICollection<TicketEntity>)await _ticketRepository.GetFirstBySpecAsync(new TicketsSpecifications.GetByIds(sessionFormDTO.Tickets));

            await _sessionRepository.InsertAsync(session);

            foreach (var ticket in session.Tickets)
            {
                _ticketRepository.Attach(ticket);
            }

            await _sessionRepository.SaveAsync();
        }

        public async Task UpdateSessionAsync(SessionFormDTO sessionFormDTO)
        {
            await ClearSessionBaseRelations(sessionFormDTO.Id);

            var session = _mapper.Map<SessionEntity>(sessionFormDTO);

            session.Tickets = (ICollection<TicketEntity>)await _ticketRepository.GetListBySpecAsync(new TicketsSpecifications.GetByIds(sessionFormDTO.Tickets));

            foreach (var ticket in session.Tickets)
            {
                _ticketRepository.Update(ticket);
            }

            _sessionRepository.Update(session);
            await _sessionRepository.SaveAsync();
        }

        public async Task ClearSessionBaseRelations(int sessionId)
        {
            var session = await _sessionRepository.GetFirstBySpecAsync(new SessionsSpecifications.GetByIdWithRel(sessionId));
            session.Tickets.Clear();
            _sessionRepository.Update(session);
            await _sessionRepository.SaveAsync();
            _sessionRepository.CrearTracker();
        }

        public async Task DeleteSessionAsync(int sessionId)
        {
            _sessionRepository.Delete(sessionId);
            await _sessionRepository.SaveAsync();
        }
    }
}

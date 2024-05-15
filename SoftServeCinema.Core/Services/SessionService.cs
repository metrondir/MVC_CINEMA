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

        public async Task<List<SessionDTO>> GetAllSessionsAsync()
        {
            var result = await _sessionRepository.GetAllAsync();
            return _mapper.Map<List<SessionDTO>>(result);
        }

        public async Task<List<SessionDTO>> GetSessionsByDayAsync(DateTime dateTime)
        {
            var result = await _sessionRepository.GetListBySpecAsync(new SessionsSpecifications.GetByStartDateDay(dateTime));
            return _mapper.Map<List<SessionDTO>>(result);
        }

        public async Task<SessionDTO> GetSessionFormByIdAsync(int sessionId)
        {
            var session = await _sessionRepository.GetFirstBySpecAsync(new SessionsSpecifications.GetByIdForForm(sessionId));
            return _mapper.Map<SessionDTO>(session);
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

        public async Task CreateSessionAsync(SessionDTO sessionFormDTO)
        {
            var session = _mapper.Map<SessionEntity>(sessionFormDTO);

            await _sessionRepository.InsertAsync(session);

            foreach (var ticket in session.Tickets)
            {
                _ticketRepository.Attach(ticket);
            }

            await _sessionRepository.SaveAsync();

            int seseionId = (await _sessionRepository.GetAllAsync()).Max(s => s.Id);

            for (int i = 1; i <= 6; i++)
            {
                for (int j = 1; j <= 6; j++)
                {
                    await _ticketRepository.InsertAsync(new TicketEntity
                    {
                        SessionId = seseionId,
                        RowNumber = i,
                        SeatNumber = j,
                        Status = "Available"
                    });
                }
            }
            await _ticketRepository.SaveAsync();
        }
        public async Task UpdateSessionAsync(SessionDTO sessionFormDTO)
        {
            await ClearSessionBaseRelationsAsync(sessionFormDTO.Id);

            var session = _mapper.Map<SessionEntity>(sessionFormDTO);

            session.Tickets = (ICollection<TicketEntity>)await _ticketRepository.GetListBySpecAsync(new TicketsSpecifications.GetByIds(sessionFormDTO.Tickets.Select(t => t.Id).ToArray()));

            foreach (var ticket in session.Tickets)
            {
                _ticketRepository.Update(ticket);
            }

            _sessionRepository.Update(session);
            await _sessionRepository.SaveAsync();
        }

        public async Task ClearSessionBaseRelationsAsync(int sessionId)
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

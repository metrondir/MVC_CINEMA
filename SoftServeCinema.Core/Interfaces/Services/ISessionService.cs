using SoftServeCinema.Core.DTOs.Sessions;

namespace SoftServeCinema.Core.Interfaces.Services
{
    public interface ISessionService
    {
        Task<List<SessionFormDTO>> GetAllSessionsAsync();
        Task<List<SessionFormDTO>> GetSessionsByDay(DateTime dateTime);
        Task<SessionFormDTO> GetSessionFormByIdAsync(int sessionId);
        Task<bool> IsSessionUniqueAsync(DateTime startDateTime);
        Task CreateSessionAsync(SessionFormDTO sessionFormDTO);
        Task UpdateSessionAsync(SessionFormDTO sessionFormDTO);
        Task ClearSessionBaseRelations(int sessionId);
        Task DeleteSessionAsync(int sessionId);
    }
}

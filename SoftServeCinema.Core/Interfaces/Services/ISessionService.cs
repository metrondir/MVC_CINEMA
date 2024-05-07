using SoftServeCinema.Core.DTOs.Sessions;

namespace SoftServeCinema.Core.Interfaces.Services
{
    public interface ISessionService
    {
        Task<List<SessionDTO>> GetAllSessionsAsync();
        Task<List<SessionDTO>> GetSessionsByDay(DateTime dateTime);
        Task<SessionDTO> GetSessionFormByIdAsync(int sessionId);
        Task<bool> IsSessionUniqueAsync(DateTime startDateTime);
        Task CreateSessionAsync(SessionDTO sessionFormDTO);
        Task UpdateSessionAsync(SessionDTO sessionFormDTO);
        Task ClearSessionBaseRelations(int sessionId);
        Task DeleteSessionAsync(int sessionId);
    }
}

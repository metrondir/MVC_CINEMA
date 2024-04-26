using SoftServeCinema.Core.DTOs.Actors;

namespace SoftServeCinema.Core.Interfaces.Services
{
    public interface IActorService
    {
        Task<List<ActorDTO>> GetAllActorsAsync();
        Task<ActorDTO> GetActorByIdAsync(int actorId);
        Task<ActorWithMoviesDTO> GetActorWithMoviesAsync(int actorId);
        Task<bool> IsNameUniqueAsync(string name);
        Task<bool> IsNameUniqueWithoutIdAsync(int actorId, string name);
        Task CreateActorAsync(ActorDTO actorDTO);
        Task UpdateActorAsync(ActorDTO actorDTO);
        Task DeleteActorAsync(int actorId);
    }
}

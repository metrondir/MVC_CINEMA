using SoftServeCinema.Core.DTOs.Directors;

namespace SoftServeCinema.Core.Interfaces.Services
{
    public interface IDirectorService
    {
        Task<List<DirectorDTO>> GetAllDirectorsAsync();
        Task<DirectorDTO> GetDirectorByIdAsync(int directorId);
        Task<DirectorWithMoviesDTO> GetDirectorWithMoviesAsync(int directorId);
        Task<bool> IsNameUniqueAsync(string name);
        Task<bool> IsNameUniqueWithoutIdAsync(int directorId, string name);
        Task CreateDirectorAsync(DirectorDTO directorDTO);
        Task UpdateDirectorAsync(DirectorDTO directorDTO);
        Task DeleteDirectorAsync(int directorId);
    }
}

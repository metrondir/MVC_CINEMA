using SoftServeCinema.Core.DTOs.Movies;

namespace SoftServeCinema.Core.Interfaces.Services
{
    public interface IMovieService
    {
        Task<List<MovieDTO>> GetActualsAsync();
        Task<List<MovieDTO>> GetExpectedAsync();
        Task<List<MovieDTO>> GetAllMoviesAsync();
        Task<MovieFullDTO> GetMovieByIdAsync(int movieId);
        Task<MovieFullDTO> GetFullMovieByIdAsync(int movieId);
        Task<MovieFormDTO> GetMovieFormByIdAsync(int movieId);
        Task<bool> IsTitleUniqueAsync(string title);
        Task<bool> IsTitleUniqueWithoutIdAsync(int movieId, string title);
        Task CreateMovieAsync(MovieFormDTO movieFormDTO, string imagePath);
        Task UpdateMovieAsync(MovieFormDTO movieFormDTO, string? imagePath);
        Task ClearMovieBaseRelations(int movieId);
        Task DeleteMovieAsync(int movieId);
    }
}

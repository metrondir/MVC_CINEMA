using SoftServeCinema.Core.DTOs.Movies;

namespace SoftServeCinema.Core.Interfaces.Services
{
    public interface IMovieService
    {
        Task<List<MovieDTO>> GetActualsAsync();
        Task<MovieFullDTO> GetMovieByIdAsync(int movieId);
        Task CreateMovieAsync(MovieFullDTO movieDTO);
        Task UpdateMovieAsync(MovieFullDTO movieDTO);
        Task DeleteMovieAsync(int movieId);
    }
}

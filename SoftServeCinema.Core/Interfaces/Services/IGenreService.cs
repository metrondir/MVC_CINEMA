using SoftServeCinema.Core.DTOs.Genres;

namespace SoftServeCinema.Core.Interfaces.Services
{
    public interface IGenreService
    {
        Task<List<GenreDTO>> GetAllGenresAsync();
        Task<List<GenreDTO>> GetGenresByIdsAsync(ICollection<int> genreIds);
        Task<GenreDTO> GetGenreByIdAsync(int genreId);
        Task<GenreWithMoviesDTO> GetGenreWithMoviesAsync(int genreId);
        Task<bool> IsNameUniqueAsync(string name);
        Task<bool> IsNameUniqueWithoutIdAsync(int genreId, string name);
        Task CreateGenreAsync(GenreDTO genreDTO);
        Task UpdateGenreAsync(GenreDTO genreDTO);
        Task DeleteGenreAsync(int genreId);
    }
}

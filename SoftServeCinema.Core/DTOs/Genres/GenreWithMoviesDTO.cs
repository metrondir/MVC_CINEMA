using SoftServeCinema.Core.DTOs.Movies;

namespace SoftServeCinema.Core.DTOs.Genres
{
    public class GenreWithMoviesDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public ICollection<MovieDTO> Movies { get; set; } = [];
    }
}

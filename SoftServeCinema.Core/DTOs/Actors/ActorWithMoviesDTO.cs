using SoftServeCinema.Core.DTOs.Movies;

namespace SoftServeCinema.Core.DTOs.Actors
{
    public class ActorWithMoviesDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public ICollection<MovieDTO> Movies { get; set; } = [];
    }
}

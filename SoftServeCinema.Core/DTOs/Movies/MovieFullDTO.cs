using SoftServeCinema.Core.DTOs.Genres;

namespace SoftServeCinema.Core.DTOs.Movies
{
    public class MovieFullDTO
    {
        public int Id { get; set; }
        public string ImagePath { get; set; } = string.Empty;
        public string TrailerUrl { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Desc { get; set; } = string.Empty;
        public int GraduationYear { get; set; } = 0;
        public int Duration { get; set; } = 0;
        public DateTime StartRentalDate { get; set; }
        public DateTime EndRentalDate { get; set; }

        public ICollection<GenreDTO> Genres { get; set; } = [];
        public ICollection<TagDTO> Tags { get; set; } = [];
        public ICollection<DirectorDTO> Directors { get; set; } = [];
        public ICollection<ActorDTO> Actors { get; set; } = [];
        public ICollection<SessionDTO> Sessions { get; set; } = [];
    }
}

using SoftServeCinema.Core.DTOs.Directors;
using SoftServeCinema.Core.DTOs.Genres;
using SoftServeCinema.Core.DTOs.Tags;

namespace SoftServeCinema.Core.DTOs.Movies
{
    public class MovieDTO
    {
        public int Id { get; set; }
        public string ImagePath { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public int GraduationYear { get; set; } = 0;
        public int Duration { get; set; } = 0;
        public DateTime StartRentalDate { get; set; }
        public DateTime EndRentalDate { get; set; }

        public ICollection<GenreDTO> Genres { get; set; } = [];
        public ICollection<TagDTO> Tags { get; set; } = [];
        public ICollection<DirectorDTO> Directors { get; set; } = [];
    }
}

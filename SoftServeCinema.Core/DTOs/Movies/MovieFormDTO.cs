using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SoftServeCinema.Core.DTOs.Movies
{
    public class MovieFormDTO
    {
        public int Id { get; set; }
        public IFormFile? ImageFile { get; set; }
        public string TrailerUrl { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Desc { get; set; } = string.Empty;
        public int GraduationYear { get; set; } = 0;
        public int Duration { get; set; } = 0;
        public DateTime StartRentalDate { get; set; }
        public DateTime EndRentalDate { get; set; }

        public List<int> SelectedGenres { get; set; } = [];
        public List<int> SelectedTags { get; set; } = [];
        public List<int> SelectedDirectors { get; set; } = [];
        public List<int> SelectedActors { get; set; } = [];
    }
}

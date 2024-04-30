using SoftServeCinema.Core.Interfaces;

namespace SoftServeCinema.Core.Entities
{
    public class MovieEntity : IEntity
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

        public ICollection<GenreEntity> Genres { get; set; } = new List<GenreEntity>();
        public ICollection<TagEntity> Tags { get; set; } = new List<TagEntity>();
        public ICollection<DirectorEntity> Directors { get; set; } = new List<DirectorEntity>();
        public ICollection<ActorEntity> Actors { get; set; } = new List<ActorEntity>();
        public ICollection<SessionEntity> Sessions { get; set; } = new List<SessionEntity>();
    }
}

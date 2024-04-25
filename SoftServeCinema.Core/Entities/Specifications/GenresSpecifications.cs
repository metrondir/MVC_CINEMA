using Ardalis.Specification;

namespace SoftServeCinema.Core.Entities.Specifications
{
    public class GenresSpecifications
    {
        public class GetByName : Specification<GenreEntity>
        {
            public GetByName(string name)
            {
                Query
                    .Where(g => g.Name.ToLower() == name.ToLower());
            }
        }

        public class GetByNameWithoutId : Specification<GenreEntity>
        {
            public GetByNameWithoutId(int genreId, string name)
            {
                Query
                    .Where(g => g.Name.ToLower() == name.ToLower() && g.Id != genreId);
            }
        }

        public class GetByIdWithMovies : Specification<GenreEntity>
        {
            public GetByIdWithMovies(int genreId)
            {
                Query
                    .Where(g => g.Id == genreId)
                    .Include(g => g.Movies)
                        .ThenInclude(m => m.Genres)
                    .Include(g => g.Movies)
                        .ThenInclude(m => m.Tags)
                    .Include(g => g.Movies)
                        .ThenInclude(m => m.Directors);

            }
        }
    }
}

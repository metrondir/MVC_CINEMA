using Ardalis.Specification;

namespace SoftServeCinema.Core.Entities.Specifications
{
    public class GenresSpecifications
    {
        public class GetByIds : Specification<GenreEntity>
        {
            public GetByIds(ICollection<int> genreIds)
            {
                Query
                    .Where(g => genreIds.Contains(g.Id))
                    .AsNoTracking();
            }
        }

        public class GetByName : Specification<GenreEntity>
        {
            public GetByName(string name)
            {
                Query
                    .Where(g => g.Name.ToLower().Trim() == name.ToLower().Trim())
                    .AsNoTracking();
            }
        }

        public class GetByNameWithoutId : Specification<GenreEntity>
        {
            public GetByNameWithoutId(int genreId, string name)
            {
                Query
                    .Where(g => g.Name.ToLower().Trim() == name.ToLower().Trim() && g.Id != genreId)
                    .AsNoTracking();
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

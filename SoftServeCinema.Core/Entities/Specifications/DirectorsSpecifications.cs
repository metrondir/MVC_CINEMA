using Ardalis.Specification;

namespace SoftServeCinema.Core.Entities.Specifications
{
    public class DirectorsSpecifications
    {
        public class GetByIds : Specification<DirectorEntity>
        {
            public GetByIds(ICollection<int> directorIds)
            {
                Query
                    .Where(d => directorIds.Contains(d.Id))
                    .AsNoTracking();
            }
        }
        public class GetByName : Specification<DirectorEntity>
        {
            public GetByName(string name)
            {
                Query
                    .Where(d => d.Name.ToLower().Trim() == name.ToLower().Trim())
                    .AsNoTracking();
            }
        }

        public class GetByNameWithoutId : Specification<DirectorEntity>
        {
            public GetByNameWithoutId(int directorId, string name)
            {
                Query
                    .Where(d => d.Name.ToLower().Trim() == name.ToLower().Trim() && d.Id != directorId)
                    .AsNoTracking();
            }
        }

        public class GetByIdWithMovies : Specification<DirectorEntity>
        {
            public GetByIdWithMovies(int directorId)
            {
                Query
                    .Where(d => d.Id == directorId)
                    .Include(d => d.Movies)
                        .ThenInclude(m => m.Genres)
                    .Include(d => d.Movies)
                        .ThenInclude(m => m.Tags)
                    .Include(d => d.Movies)
                        .ThenInclude(m => m.Directors);
            }
        }
    }
}

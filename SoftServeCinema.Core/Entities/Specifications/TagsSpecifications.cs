using Ardalis.Specification;

namespace SoftServeCinema.Core.Entities.Specifications
{
    public class TagsSpecifications
    {
        public class GetByIds : Specification<TagEntity>
        {
            public GetByIds(ICollection<int> tagIds)
            {
                Query
                    .Where(t => tagIds.Contains(t.Id))
                    .AsNoTracking();
            }
        }

        public class GetByName : Specification<TagEntity>
        {
            public GetByName(string name)
            {
                Query
                    .Where(t => t.Name.ToLower().Trim() == name.ToLower().Trim())
                    .AsNoTracking();
            }
        }

        public class GetByNameWithoutId : Specification<TagEntity>
        {
            public GetByNameWithoutId(int tagId, string name)
            {
                Query
                    .Where(t => t.Name.ToLower().Trim() == name.ToLower().Trim() && t.Id != tagId)
                    .AsNoTracking();
            }
        }

        public class GetByIdWithMovies : Specification<TagEntity>
        {
            public GetByIdWithMovies(int tagId)
            {
                Query
                    .Where(t => t.Id == tagId)
                    .Include(t => t.Movies)
                        .ThenInclude(m => m.Genres)
                    .Include(t => t.Movies)
                        .ThenInclude(m => m.Tags)
                    .Include(t => t.Movies)
                        .ThenInclude(m => m.Directors);
            }
        }
    }
}

using Ardalis.Specification;

namespace SoftServeCinema.Core.Entities.Specifications
{
    public class ActorsSpecifications
    {
        public class GetByName : Specification<ActorEntity>
        {
            public GetByName(string name)
            {
                Query
                    .Where(a => a.Name.ToLower().Trim() == name.ToLower().Trim());
            }
        }

        public class GetByNameWithoutId : Specification<ActorEntity>
        {
            public GetByNameWithoutId(int actorId, string name)
            {
                Query
                    .Where(a => a.Name.ToLower().Trim() == name.ToLower().Trim() && a.Id != actorId);
            }
        }

        public class GetByIdWithMovies : Specification<ActorEntity>
        {
            public GetByIdWithMovies(int actorId)
            {
                Query
                    .Where(a => a.Id == actorId)
                    .Include(a => a.Movies)
                        .ThenInclude(m => m.Genres)
                    .Include(a => a.Movies)
                        .ThenInclude(m => m.Tags)
                    .Include(a => a.Movies)
                        .ThenInclude(m => m.Directors);

            }
        }
    }
}

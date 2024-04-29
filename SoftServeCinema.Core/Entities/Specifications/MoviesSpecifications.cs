using Ardalis.Specification;

namespace SoftServeCinema.Core.Entities.Specifications
{
    public class MoviesSpecifications
    {
        public class GetByTitle : Specification<MovieEntity>
        {
            public GetByTitle(string title)
            {
                Query
                    .Where(m => m.Title.ToLower().Trim() == title.ToLower().Trim())
                    .AsNoTracking();
            }
        }

        public class GetByTitleWithoutId : Specification<MovieEntity>
        {
            public GetByTitleWithoutId(int movieId, string title)
            {
                Query
                    .Where(m => m.Title.ToLower().Trim() == title.ToLower().Trim() && m.Id != movieId)
                    .AsNoTracking();
            }
        }

        public class GetActuals : Specification<MovieEntity>
        {
            public GetActuals()
            {
                Query
                    .Where(m => m.StartRentalDate <=  DateTime.Now)
                    .Where(m => m.EndRentalDate >=  DateTime.Now)
                    .Include(m => m.Genres)
                    .Include(m => m.Tags)
                    .Include(m => m.Directors)
                    .AsNoTracking();
            }
        }

        public class GetExpected : Specification<MovieEntity>
        {
            public GetExpected()
            {
                Query
                    .Where(m => m.StartRentalDate > DateTime.Now)
                    .Include(m => m.Genres)
                    .Include(m => m.Tags)
                    .Include(m => m.Directors)
                    .OrderBy(m => m.StartRentalDate)
                    .AsNoTracking();
            }
        }

        public class GetByIdForForm : Specification<MovieEntity>
        {
            public GetByIdForForm(int movieId)
            {
                Query
                    .Where(m => m.Id == movieId)
                    .Include(m => m.Genres)
                    .Include(m => m.Tags)
                    .Include(m => m.Directors)
                    .Include(m => m.Actors)
                    .AsNoTracking();
            }
        }

        public class GetByIdWithRel : Specification<MovieEntity>
        {
            public GetByIdWithRel(int movieId)
            {
                Query
                    .Where(m => m.Id == movieId)
                    .Include(m => m.Genres)
                    .Include(m => m.Tags)
                    .Include(m => m.Directors)
                    .Include(m => m.Actors);
            }
        }
    }
}

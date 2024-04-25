using Ardalis.Specification;

namespace SoftServeCinema.Core.Entities.Specifications
{
    public class MoviesSpecifications
    {
        public class GetActuals : Specification<MovieEntity>
        {
            public GetActuals()
            {
                Query
                    .Where(m => m.StartRentalDate <=  DateTime.Now)
                    .Where(m => m.EndRentalDate >=  DateTime.Now)
                    .Include(m => m.Genres)
                    .Include(m => m.Tags)
                    .Include(m => m.Directors);
            }
        }
    }
}

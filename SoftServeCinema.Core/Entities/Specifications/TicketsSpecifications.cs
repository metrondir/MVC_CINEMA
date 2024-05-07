using Ardalis.Specification;

namespace SoftServeCinema.Core.Entities.Specifications
{
    public class TicketsSpecifications
    {
        public class GetByIds : Specification<TicketEntity>
        {
            public GetByIds(ICollection<int> ticketIds)
            {
                Query
                    .Where(t => ticketIds.Contains(t.Id))
                    .AsNoTracking();
            }
        }

        public class GetAvailable : Specification<TicketEntity>
        {
            public GetAvailable()
            {
                Query
                    .Where(t => t.Status == "Available")
                    .AsNoTracking();
            }
        }
    }
}

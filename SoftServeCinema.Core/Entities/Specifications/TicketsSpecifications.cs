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
        public class GetReservedByUserId : Specification<TicketEntity>
        {
            public GetReservedByUserId(string userId)
            {
                Query
                    .Where(t => t.Status == "Reservation")
                    .Where(t => t.UserId == Guid.Parse(userId))
                    .Include(t => t.Session)
                    .ThenInclude(s => s.Movie)
                    .AsNoTracking();
            }
        }
        public class GetTicketsWithDetails : Specification<TicketEntity>
        {
            public GetTicketsWithDetails(ICollection<int>  ticketsIds )
            {
                Query
                     .Where(t => ticketsIds.Contains(t.Id))
                    .Include(t => t.Session)
                    .ThenInclude(s => s.Movie)
                    .AsNoTracking();
            }
        }
        public class GetBoughtByUserId : Specification<TicketEntity>
        {
            public GetBoughtByUserId(string userId)
            {
                Query
                    .Where(t => t.Status == "Bought")
                    .Where(t => t.UserId == Guid.Parse(userId))
                     .Include(t => t.Session)
                    .ThenInclude(s => s.Movie)
                    .AsNoTracking();
            }
        }
        public class GetTicketsWithUser : Specification<TicketEntity>
        {
            public GetTicketsWithUser(ICollection<int> ticketIds)
            {
                Query
                    .Where(t => ticketIds.Contains(t.Id))
                     .Include(t => t.Session)
                    .ThenInclude(s => s.Movie)   
                    .Include(t => t.User)
                    .AsNoTracking();
            }
        }
    }
}

using Ardalis.Specification;

namespace SoftServeCinema.Core.Entities.Specifications
{
    public class SessionsSpecifications
    {
        public class GetByStartDateDay : Specification<SessionEntity>
        {
            public GetByStartDateDay(DateTime startDate)
            {
                Query
                    .Where(s => s.StartDate.Day == startDate.Day)
                    .AsNoTracking();
            }
        }

        public class GetByStartDateTime : Specification<SessionEntity>
        {
            public GetByStartDateTime(DateTime startDateTime)
            {
                Query
                    .Where(s => s.StartDate.Date == startDateTime.Date && s.StartDate.TimeOfDay == startDateTime.TimeOfDay)
                    .AsNoTracking();
            }
        }

        public class GetByIdForForm : Specification<SessionEntity>
        {
            public GetByIdForForm(int sessionId)
            {
                Query
                    .Where(s => s.Id == sessionId)
                    .Include(s => s.Tickets)
                    .AsNoTracking();
            }
        }

        public class GetByIdWithRel : Specification<SessionEntity>
        {
            public GetByIdWithRel(int sessionId)
            {
                Query
                    .Where(s => s.Id == sessionId)
                    .Include(s => s.Tickets);
            }
        }
    }
}

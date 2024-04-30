using SoftServeCinema.Core.Interfaces;

namespace SoftServeCinema.Core.Entities
{
    public class SessionEntity : IEntity
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public MovieEntity? Movie { get; set; }
        public DateTime StartDate { get; set; }
        public decimal BasicPrice { get; set; } = 0;
        public decimal VipPrice { get; set; } = 0;

        public ICollection<TicketEntity> Tickets { get; set; } = new List<TicketEntity>();
    }
}

using SoftServeCinema.Core.Interfaces;

namespace SoftServeCinema.Core.Entities
{
    public class TicketEntity : IEntity
    {
        public int Id { get; set; }
        public int SessionId { get; set; }
        public SessionEntity? Session { get; set; }
        public Guid UserId { get; set; }
        public UserEntity? User { get; set; }
        public int RowNumber { get; set; } = 0;
        public int SeatNumber { get; set; } = 0;
        public DateTime ReservationDate { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}

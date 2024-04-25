namespace SoftServeCinema.Core.DTOs
{
    public class SessionDTO
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public DateTime StartDate { get; set; }
        public decimal BasicPrice { get; set; } = 0;
        public decimal VipPrice { get; set; } = 0;

        public ICollection<TicketDTO> Tickets { get; set; } = [];
    }
}

namespace SoftServeCinema.Core.DTOs.Sessions
{
    public class SessionFormDTO
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public DateTime StartDate { get; set; }
        public decimal BasicPrice { get; set; } = 0;
        public decimal VipPrice { get; set; } = 0;

        public List<int> Tickets { get; set; } = [];
    }
}

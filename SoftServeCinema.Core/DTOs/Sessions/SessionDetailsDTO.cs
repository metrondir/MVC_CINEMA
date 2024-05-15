namespace SoftServeCinema.Core.DTOs.Sessions
{
    public class SessionDetailsDTO
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public string MovieTitle { get; set; }
        public string MovieImagePath { get; set; }
        public DateTime StartDate { get; set; }
        public decimal BasicPrice { get; set; } = 0;
        public decimal VipPrice { get; set; } = 0;
    }
}

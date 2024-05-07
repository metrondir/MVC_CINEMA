namespace SoftServeCinema.Core.DTOs.Sessions
{
    public class SessionViewModelDTO
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public string MovieTitle { get; set; }
        public DateTime StartDate { get; set; }
        public int TicketsCount { get; set; }
    }
}

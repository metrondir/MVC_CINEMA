﻿namespace SoftServeCinema.Core.DTOs
{
    public class TicketDTO
    {
        public int Id { get; set; }
        public int SessionId { get; set; }
        public int RowNumber { get; set; } = 0;
        public int SeatNumber { get; set; } = 0;
        public DateTime ReservationDate { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}

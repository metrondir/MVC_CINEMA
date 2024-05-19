using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftServeCinema.Core.DTOs.Tickets
{
    public class TicketDetailWithUserDTO
    {
        public int Id { get; set; }
        public int SessionId { get; set; }
        public Sessions.SessionDetailsDTO Session { get; set; }
        public int RowNumber { get; set; } = 0;
        public int SeatNumber { get; set; } = 0;
        public DateTime ReservationDate { get; set; }
        public string Status { get; set; } = string.Empty;
        public Guid UserId { get; set; }

        public Users.UserDTO User { get; set; }
    }

}

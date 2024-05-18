using Ardalis.Specification;
using SoftServeCinema.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftServeCinema.Core.Entities
{

    public class UserEntity :IGuidEntity
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string RoleName { get; set; }
        public ICollection<PaymentEntity> Payments { get; set; }
        public ICollection<TicketEntity> Tickets { get; set; } = [];

    }
}

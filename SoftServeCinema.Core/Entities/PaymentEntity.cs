using Ardalis.Specification;
using SoftServeCinema.Core.DTOs.Tickets;
using SoftServeCinema.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftServeCinema.Core.Entities
{
    public  class PaymentEntity : IEntity
    {
        public int Id { get; set; }
        public Guid? UserId { get; set; }
        public UserEntity? User { get; set; }

        public decimal TotalAmount { get; set; }
        public DateTime PaymentDate { get; set; }

    }
}

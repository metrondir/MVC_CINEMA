using SoftServeCinema.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftServeCinema.Core.DTOs.Payment
{
    public class PaymentDTO
    {
        public int? Id { get; set; }
        public Guid UserId { get; set; }

        public decimal TotalAmount { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}

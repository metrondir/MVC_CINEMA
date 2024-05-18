using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftServeCinema.Core.DTOs.Checkout
{
    public class CheckoutOrderResponse
    {
        public string? SessionId { get; set; }

        public string? PubKey { get; set; }
    }
}

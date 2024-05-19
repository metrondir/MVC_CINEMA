using SoftServeCinema.Core.DTOs.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftServeCinema.Core.Interfaces.Services
{
    public interface IPaymentService
    {
        Task<bool> CreatePaymentAsync(PaymentDTO paymentDTO);

    }
}

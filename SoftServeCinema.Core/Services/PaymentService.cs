using AutoMapper;
using SoftServeCinema.Core.DTOs.Payment;
using SoftServeCinema.Core.DTOs.Tags;
using SoftServeCinema.Core.Entities;
using SoftServeCinema.Core.Interfaces;
using SoftServeCinema.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftServeCinema.Core.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IRepository<PaymentEntity> _paymentRepository;
        private readonly IMapper _mapper;


        public PaymentService(IMapper mapper,
                            IRepository<PaymentEntity> paymentRepository)
        {
            _mapper = mapper;
            _paymentRepository = paymentRepository;
        }

        public async Task<bool> CreatePaymentAsync(PaymentDTO paymentDTO)
        {
            var payment = _mapper.Map<PaymentEntity>(paymentDTO);
            await _paymentRepository.InsertAsync(payment);
            await _paymentRepository.SaveAsync();
            return true;
        }
    }
}

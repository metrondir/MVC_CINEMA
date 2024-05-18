using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace SoftServeCinema.Core.Entities.Specifications
{
    public class PaymentsSpecification
    {
        public class GetAllByUserId : Specification<PaymentEntity>
        {
            public GetAllByUserId(Guid userId)
            {
                Query
                     .Where(p => p.UserId == userId)
                    .AsNoTracking();
            }
        }
    }
}

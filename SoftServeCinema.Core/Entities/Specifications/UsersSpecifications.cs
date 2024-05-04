using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace SoftServeCinema.Core.Entities.Specifications
{
    public class UsersSpecifications
    {

        public class GetUserWithTickets : Specification<UserEntity>
        {
            public GetUserWithTickets(string userId)
            {
                Query
                    .Where(t => t.Id.ToString() == userId)
                    .Include(t => t.Tickets);
                    
            }
        }
        public class GetUserByEmail : Specification<UserEntity>
        {
            public GetUserByEmail(string email)
            {
                Query
                   .Where(t => t.Email == email);
                   //.Include(t => t.Tickets);
            }
        }
    }
}

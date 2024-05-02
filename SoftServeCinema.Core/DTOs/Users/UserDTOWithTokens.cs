using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftServeCinema.Core.DTOs.Users
{
    public  class UserDTOWithTokens
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}

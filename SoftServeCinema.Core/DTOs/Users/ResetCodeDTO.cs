using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftServeCinema.Core.DTOs.Users
{
    public class ResetCodeDTO
    {
        public string ResetToken { get; set; }
        public string Email { get; set; }
        public string NewPassword { get; set; }

    }
}

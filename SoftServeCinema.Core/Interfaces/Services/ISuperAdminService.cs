using SoftServeCinema.Core.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftServeCinema.Core.Interfaces.Services
{
    public  interface ISuperAdminService
    {
        Task <bool> ChangeRoleAsync(ChangeRoleDTO changeRoleDTO);

        Task<List<UserDTO>> GetAllUsers();
    }
}

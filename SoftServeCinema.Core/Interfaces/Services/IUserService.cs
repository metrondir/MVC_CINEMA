using SoftServeCinema.Core.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftServeCinema.Core.Interfaces.Services
{
   public interface  IUserService 
    {
        Task<UserDTO> GetUserByIdAsync(Guid id );
        Task<UserWithTicketsDTO> GetUserWithTicketsByIdAsync(string id);
        Task<UserRegisterDTO> Create(UserRegisterDTO userDTO);
        Task<bool> Delete(Guid id, CancellationToken cancellationToken);
        
        Task<bool> Exist(Guid id);
  
    }
}

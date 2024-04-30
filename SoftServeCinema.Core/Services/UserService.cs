using AutoMapper;
using SoftServeCinema.Core.DTOs.Tags;
using SoftServeCinema.Core.DTOs.Users;
using SoftServeCinema.Core.Entities;
using SoftServeCinema.Core.Entities.Specifications;
using SoftServeCinema.Core.Exceptions;
using SoftServeCinema.Core.Interfaces;
using SoftServeCinema.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftServeCinema.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IGuidRepository<UserEntity> _userRepository;

        public UserService(IMapper mapper,
                            IGuidRepository<UserEntity> userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<UserDTO> GetUserByIdAsync(Guid id)
        {
            var user = (await _userRepository.GetByIdAsync(id)) ?? throw new EntityNotFoundException();
            return _mapper.Map<UserDTO>(user);
        }
        public async Task<UserWithTicketsDTO> GetUserWithTicketsByIdAsync(string id)
        {
            var user = (await _userRepository.GetFirstBySpecAsync(new UsersSpecifications.GetUserWithTickets(id))) ?? throw new EntityNotFoundException();
            return _mapper.Map<UserWithTicketsDTO>(user);
        }
        
        public async Task<UserRegisterDTO> Create(UserRegisterDTO userRegisterDTO)
        {
           var user = new UserEntity
           {
               Id = userRegisterDTO.Id,
               FirstName = userRegisterDTO.FirstName,
               LastName = userRegisterDTO.LastName,
               Email = userRegisterDTO.Email,
               RoleName = userRegisterDTO.RoleName
           };
           await _userRepository.InsertAsync(user);
           await _userRepository.SaveAsync();
           return _mapper.Map<UserRegisterDTO>(user);
        }
       
        public async Task<bool> Delete(Guid id, CancellationToken cancellationToken)
        {
           if(!await _userRepository.ExistAsync(id))
            {
                return false;
           }
           var user = await _userRepository.GetByIdAsync(id);
             _userRepository.Delete(id);
            await _userRepository.SaveAsync();
            return true;
        }

        public Task<bool> Exist(Guid id)
        {
            return _userRepository.ExistAsync(id);
        }

       
    }
}

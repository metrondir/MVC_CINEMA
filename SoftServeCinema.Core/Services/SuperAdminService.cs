using AutoMapper;
using Microsoft.AspNetCore.Http;
using SoftServeCinema.Core.DTOs.Users;
using SoftServeCinema.Core.Entities;
using SoftServeCinema.Core.Entities.Specifications;
using SoftServeCinema.Core.Interfaces;
using SoftServeCinema.Core.Interfaces.Services;
using static SoftServeCinema.Core.Entities.Specifications.UsersSpecifications;

namespace SoftServeCinema.Core.Services
{
    public class SuperAdminService : ISuperAdminService
    {
        private readonly IMapper _mapper;
        private readonly IGuidRepository<UserEntity> _userRepository;

        public SuperAdminService(IMapper mapper,
                                            IGuidRepository<UserEntity> userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }
        public async Task<List<UserDTO>> GetAllUsers()
        {
            var result = await _userRepository.GetAllAsync();
            return _mapper.Map<List<UserDTO>>(result);
        }
       

        public async Task<bool> ChangeRoleAsync(ChangeRoleDTO changeRoleDTO)
        {
            if (!await _userRepository.ExistsAsync(new GetUserByEmail(changeRoleDTO.Email)))
            {
                return false;
            }
            var user = await _userRepository.GetFirstBySpecAsync(new GetUserByEmail(changeRoleDTO.Email));

            user.RoleName = changeRoleDTO.RoleName;
            await _userRepository.UpdateAsync(user);
            return true;

        }
    }
}

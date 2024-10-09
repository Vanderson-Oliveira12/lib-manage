using LibManage.DTOs.User;
using LibManage.Repositories.Users;
using Microsoft.AspNetCore.Mvc;
using LibManage.Models;

namespace LibManage.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<ResponseUserDTO>> GetAllUsersAsync()
        {

            var users = await _userRepository.GetAllAsync();

            IEnumerable<ResponseUserDTO> usersDTO = users.Select(user => new ResponseUserDTO
            {
                Id = user.Id,
                Name = user.Name,
                Phone = user.Phone,
                Role = user.Role.ToString(),
                Email = user.Email
            }).ToList();

            return usersDTO;
        }

        public async Task<ResponseUserDTO> GetUserByIdAsync(Guid id)
        {

            var user = await _userRepository.FindByIdAsync(id);

            ResponseUserDTO userDTO = new ResponseUserDTO
            {
                Id = user.Id,
                Name = user.Name,
                Phone = user.Phone,
                Role = user.Role.ToString(),
                Email = user.Email
            };

            return userDTO;
        }

        public async Task CreateUserAsync([FromBody] CreateUserDTO userDTO)
        {

            User user = new User
            {
                Name = userDTO.Name,
                Email = userDTO.Email,
                Phone = userDTO.Phone,
            };

            await _userRepository.CreateAsync(user);
        }

        public async Task UpdateUserAsync(Guid id, [FromBody] UpdateUserDTO userDTO)
        {

            User user = await _userRepository.FindByIdAsync(id);

            if ( !string.IsNullOrEmpty(userDTO.Name) )
            {
                user.Name = userDTO.Name;
            }

            if ( !string.IsNullOrEmpty(userDTO.Email) )
            {
                user.Email = userDTO.Email;
            }

            await _userRepository.UpdateAsync(user);
        }

        public async Task DeleteUserAsync(Guid id)
        {
            await _userRepository.DeleteAsync(id);
        }
    }
}

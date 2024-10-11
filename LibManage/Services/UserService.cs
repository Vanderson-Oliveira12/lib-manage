using Microsoft.AspNetCore.Mvc;
using LibManage.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using LibManage.Services.Interfaces;
using LibManage.Repositories.Interfaces;
using AutoMapper;
using LibManage.DTOs;

namespace LibManage.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<IEnumerable<ResponseUserDTO>>> GetAllUsersAsync()
        {

            IEnumerable<User> users = await _userRepository.GetAllAsync();

            if (users is null || !users.Any())
            {
                return new ApiResponse<IEnumerable<ResponseUserDTO>>().Error(null, 404);
            }

            IEnumerable<ResponseUserDTO> usersListDTO = _mapper.Map<IEnumerable<ResponseUserDTO>>(users).ToList();

            return new ApiResponse<IEnumerable<ResponseUserDTO>>().Success(usersListDTO);
        }

        public async Task<ApiResponse<ResponseUserDTO>> GetUserByIdAsync(Guid id)
        {

            var user = await _userRepository.FindByIdAsync(id);

            if (user == null)
            {
                return new ApiResponse<ResponseUserDTO>().Error(status: 404);
            }

            ResponseUserDTO userDTO = _mapper.Map<ResponseUserDTO>(user);

            return new ApiResponse<ResponseUserDTO>().Success(userDTO);
        }

        public async Task<ApiResponse<CreateUserDTO>> CreateUserAsync(CreateUserDTO userDTO)
        {

            bool isEmailExists = await _userRepository.EmailExists(userDTO.Email);

            if (isEmailExists)
            {
                return new ApiResponse<CreateUserDTO>().Error(status: 400, message: "Email já registrado!");
            }

            User user = _mapper.Map<User>(userDTO);

            await _userRepository.CreateAsync(user);

            return new ApiResponse<CreateUserDTO>().Success(data: userDTO);
        }

        public async Task<ApiResponse<bool>> UpdateUserAsync(Guid id, UpdateUserDTO userDTO)
        {

            User user = await _userRepository.FindByIdAsync(id);

            if (user is null)
            {
                return new ApiResponse<bool>().Error(status: 400, message: "Usuário não encontrado");
            }

            if (!string.IsNullOrEmpty(userDTO.Name))
            {
                user.Name = userDTO.Name;
            }

            if (!string.IsNullOrEmpty(userDTO.Email))
            {
                user.Email = userDTO.Email;
            }

            await _userRepository.UpdateAsync(user);

            return new ApiResponse<bool>().Success(data: true, message: "Usuário editado com sucesso");
        }

        public async Task<ApiResponse<bool>> DeleteUserByIdAsync(Guid id)
        {

            User user = await _userRepository.FindByIdAsync(id);

            if (user is null)
            {
                return new ApiResponse<bool>().Error(status: 400, message: "Usuário não encontrado");
            }

            await _userRepository.DeleteAsync(user);

            return new ApiResponse<bool>().Success(data: true, message: "Usuário deletado com sucesso");
        }
    }
}

using LibManage.DTOs;
using LibManage.Models;

namespace LibManage.Services.Interfaces
{
    public interface IUserService
    {
        Task<ApiResponse<IEnumerable<ResponseUserDTO>>> GetAllUsersAsync();
        Task<ApiResponse<ResponseUserDTO>> GetUserByIdAsync(Guid id);
        Task<ApiResponse<CreateUserDTO>> CreateUserAsync(CreateUserDTO userDTO);
        Task<ApiResponse<bool>> UpdateUserAsync(Guid id, UpdateUserDTO userDTO);
        Task<ApiResponse<bool>> DeleteUserByIdAsync(Guid id);
    }
}

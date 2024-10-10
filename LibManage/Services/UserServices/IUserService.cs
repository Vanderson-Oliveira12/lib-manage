using LibManage.DTOs.User;
using LibManage.Models;

namespace LibManage.Services.UserServices
{
    public interface IUserService
    {
        Task<ApiResponse<IEnumerable<ResponseUserDTO>>> GetAllUsersAsync();
        Task<ApiResponse<ResponseUserDTO>> GetUserByIdAsync(Guid id);
        Task<ApiResponse<CreateUserDTO>> CreateUserAsync(CreateUserDTO userDTO);
        Task UpdateUserAsync(Guid id, UpdateUserDTO userDTO);
        Task<ApiResponse<bool>> DeleteUserByIdAsync(Guid id);
    }
}

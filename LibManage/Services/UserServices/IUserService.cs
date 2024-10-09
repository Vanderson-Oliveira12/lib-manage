using LibManage.DTOs.User;

namespace LibManage.Services.UserServices
{
    public interface IUserService
    {
        Task<IEnumerable<ResponseUserDTO>> GetAllUsersAsync();
        Task<ResponseUserDTO> GetUserByIdAsync(Guid id);
        Task CreateUserAsync(CreateUserDTO userDTO);
        Task UpdateUserAsync(Guid id, UpdateUserDTO userDTO);
        Task DeleteUserAsync(Guid id);
    }
}

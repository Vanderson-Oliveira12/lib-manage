using LibManage.DTOs;
using LibManage.Models;

namespace LibManage.Services.Interfaces
{
    public interface IBookService
    {
        Task<ApiResponse<IEnumerable<ResponseBookDTO>>> GetAllBookAsync();
        Task<ApiResponse<ResponseBookDTO>> GetByIdBookAsync(Guid id);
        Task<ApiResponse<CreateBookDTO>> CreateBookAsync(CreateBookDTO book);
        Task<ApiResponse<ResponseBookDTO>> UpdateBookAsync(Guid id, UpdateBookDTO book);
        Task<ApiResponse<bool>> DeleteBookAsync(Guid id);

    }
}

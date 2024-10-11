using LibManage.DTOs;
using LibManage.Models;

namespace LibManage.Services.Interfaces
{
    public interface IBookService
    {
        Task<ApiResponse<IEnumerable<ResponseBookDTO>>> GetAllBookAsync();
        Task<ApiResponse<ResponseBookDTO>> GetByIdBookAsync(Guid id);
        Task<ApiResponse<Book>> CreateBookAsync(Book book);
        Task<ApiResponse<bool>> UpdateBookAsync(Guid id, Book book);
        Task<ApiResponse<bool>> DeleteBookAsync(Guid id);

    }
}

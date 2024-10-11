using LibManage.Models;

namespace LibManage.Services.Interfaces
{
    public interface IBookService
    {
        Task<ApiResponse<IEnumerable<Book>>> GetAllBookAsync();
        Task<ApiResponse<Book>> GetByIdBookAsync(Guid id);

        Task<ApiResponse<Book>> CreateBookAsync(Book book);
        Task<ApiResponse<bool>> UpdateBookAsync(Guid id, Book book);
        Task<ApiResponse<bool>> DeleteBookAsync(Guid id);

    }
}

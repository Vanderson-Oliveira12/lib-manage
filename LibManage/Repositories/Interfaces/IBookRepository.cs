using LibManage.Models;

namespace LibManage.Repositories.Interfaces
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllAsync();
        Task<Book> GetByIdAsync(Guid id);
        Task CreateAsync(Book book);
        Task UpdateAsync(Book book);
        Task DeleteAsync(Book book);
    }
}

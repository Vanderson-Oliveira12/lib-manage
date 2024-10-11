using LibManage.Context;
using LibManage.Models;
using LibManage.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibManage.Repositories
{
    public class BookRepository : IBookRepository
    {

        private readonly AppDbContext _context;

        public BookRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _context.Books.ToListAsync();
        }
        public async Task<Book> GetByIdAsync(Guid id)
        {
            return await _context.Books.FindAsync(id);
        }

        public async Task CreateAsync(Book book)
        {
            await _context.Books.AddAsync(book);

            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Book book)
        {
            _context.Books.Update(book);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Book book)
        {

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }

    }
}

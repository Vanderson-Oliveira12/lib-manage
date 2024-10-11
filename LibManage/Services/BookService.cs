using LibManage.Models;
using LibManage.Repositories.Interfaces;
using LibManage.Services.Interfaces;
using System.Collections.Generic;

namespace LibManage.Services
{
    public class BookService : IBookService
    {


        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<ApiResponse<IEnumerable<Book>>> GetAllBookAsync()
        {

            IEnumerable<Book> books = await _bookRepository.GetAllAsync();

            if ( books == null || !books.Any() )
            {
                return new ApiResponse<IEnumerable<Book>>().Error(status: 404);
            }

            return new ApiResponse<IEnumerable<Book>>().Success(data: books);
        }

        public async Task<ApiResponse<Book>> GetByIdBookAsync(Guid id)
        {
            Book book = await _bookRepository.GetByIdAsync(id);

            if ( book == null ) {
                return new ApiResponse<Book>().Error(status: 404);
            }

            return new ApiResponse<Book>().Success(data: book);
        }

        public async Task<ApiResponse<Book>> CreateBookAsync(Book book)
        {
            await _bookRepository.CreateAsync(book);    

            return new ApiResponse<Book>().Success(data: book);
        }

        public async Task<ApiResponse<bool>> UpdateBookAsync(Guid id, Book bookUpdated)
        {
            Book bookExists = await _bookRepository.GetByIdAsync(id);

            if ( bookExists == null ) {
                return new ApiResponse<bool>().Error(status: 400, message: "Registro não encontrado");
            }

            if ( !string.IsNullOrEmpty(bookUpdated.Title) ) {
                bookExists.Title = bookUpdated.Title;
            }

            await _bookRepository.UpdateAsync(bookExists);

            return new ApiResponse<bool>().Success(data: true, message: "Atualizado com sucesso!");
        }

        public async Task<ApiResponse<bool>> DeleteBookAsync(Guid id)
        {
            Book bookExists = await _bookRepository.GetByIdAsync(id);

            if ( bookExists == null )
            {
                return new ApiResponse<bool>().Error(status: 400, message: "Registro não encontrado");
            }

            await _bookRepository.DeleteAsync(bookExists);

            return new ApiResponse<bool>().Success(data: true, status: 200);
        }
    }
}

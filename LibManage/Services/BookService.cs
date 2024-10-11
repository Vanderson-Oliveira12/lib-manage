using AutoMapper;
using LibManage.DTOs;
using LibManage.Models;
using LibManage.Repositories.Interfaces;
using LibManage.Services.Interfaces;

namespace LibManage.Services
{
    public class BookService : IBookService
    {
        
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<IEnumerable<ResponseBookDTO>>> GetAllBookAsync()
        {

            IEnumerable<Book> books = await _bookRepository.GetAllAsync();

            if ( books == null || !books.Any() )
            {
                return new ApiResponse<IEnumerable<ResponseBookDTO>>().Error(status: 404);
            }

            IEnumerable<ResponseBookDTO> booksListDTO = _mapper.Map<IEnumerable<ResponseBookDTO>>(books);

            return new ApiResponse<IEnumerable<ResponseBookDTO>>().Success(data: booksListDTO);
        }

        public async Task<ApiResponse<ResponseBookDTO>> GetByIdBookAsync(Guid id)
        {
            Book book = await _bookRepository.GetByIdAsync(id);

            if ( book == null ) {
                return new ApiResponse<ResponseBookDTO>().Error(status: 404);
            }

            ResponseBookDTO responseBookDTO = _mapper.Map<ResponseBookDTO>(book);

            return new ApiResponse<ResponseBookDTO>().Success(data: responseBookDTO);
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

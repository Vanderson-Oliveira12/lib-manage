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

        public async Task<ApiResponse<CreateBookDTO>> CreateBookAsync(CreateBookDTO bookDTO)
        {

            if ( int.IsNegative(bookDTO.Quantity) )
            {
                return new ApiResponse<CreateBookDTO>().Error(status: 400, message: "Não é possível registrar valores menor que 0");
            }

            Book book = _mapper.Map<Book>(bookDTO);

            await _bookRepository.CreateAsync(book);    

            return new ApiResponse<CreateBookDTO>().Success(data: bookDTO);
        }

        public async Task<ApiResponse<ResponseBookDTO>> UpdateBookAsync(Guid id, UpdateBookDTO bookUpdatedDTO)
        {
            Book bookExists = await _bookRepository.GetByIdAsync(id);

            if ( bookExists == null ) {
                return new ApiResponse<ResponseBookDTO>().Error(status: 400, message: "Registro não encontrado");
            }

            if ( !string.IsNullOrEmpty(bookUpdatedDTO.Title) ) {
                bookExists.Title = bookUpdatedDTO.Title;
            }

            if ( !int.IsNegative(bookUpdatedDTO.quantity) ) {
                bookExists.Quantity = bookUpdatedDTO.quantity;
            }

            await _bookRepository.UpdateAsync(bookExists);

            var bookDTO = _mapper.Map<ResponseBookDTO>(bookExists);

            return new ApiResponse<ResponseBookDTO>().Success(data: bookDTO, message: "Atualizado com sucesso!");
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

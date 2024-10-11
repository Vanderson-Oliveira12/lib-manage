using LibManage.Models;
using LibManage.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibManage.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BookController : ControllerBase
    {

        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllAsync()
        {
            var response = await _bookService.GetAllBookAsync();

            if ( response.IsSucceeded ) {
                return Ok(response);
            }

            if ( response.StatusCode == 404 )
            {
                return NotFound(response);
            } 

            return BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetByIdAsync(Guid id)
        {
            var response = await _bookService.GetByIdBookAsync(id);

            if ( response.IsSucceeded ) {
                return Ok(response);
            }

            if(response.StatusCode == 404)
            {
                return NotFound(response);
            } 

            return BadRequest(response);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Book book)
        {
            var response = await _bookService.CreateBookAsync(book);

            if ( response.IsSucceeded ) {
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Guid id,[FromBody] Book book)
        {
            var response = await _bookService.UpdateBookAsync(id, book);

            if ( response.IsSucceeded )
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var response = await _bookService.DeleteBookAsync(id);

            if ( response.IsSucceeded ) {
                return Ok(response);
            }

            if(response.StatusCode == 404)
            {
                return NotFound(response);
            } 

            return BadRequest(response);
        }

    }
}

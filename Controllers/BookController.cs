using Microsoft.AspNetCore.Mvc;
using my_books.Interfaces;
using my_books.Models.ViewModels;

namespace my_books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _service;
        public BookController(IBookService service)
        {
            _service = service;
        }

        [HttpGet("get-all-books")]
        public IActionResult GetAllBooks()
        {
            var lstBooks = _service.GetAllBooks();
            return Ok(lstBooks);
        }

        [HttpGet("get-book-by-id/{bookId}")]
        public IActionResult GetBookById(int bookId)
        {
            var objBook = _service.GetBookById(bookId);
            return Ok(objBook);
        }


        [HttpPost("add-book")]
        public IActionResult AddBook([FromBody] BookVM bookVm)
        {
            _service.AddBook(bookVm);
            return Ok();
        }

        [HttpPut("update-book-by-id/{bookId}")]
        public IActionResult UpdateBookById(int bookId, [FromBody] BookVM bookVM)
        {
            var objBook = _service.UpdateBookById(bookId, bookVM);
            return Ok(objBook);
        }

        [HttpDelete("remove-book-by-id/{bookId}")]
        public IActionResult DeleteBookById(int bookId)
        {
            _service.DeleteBookById(bookId);
            return Ok();
        }
    }
}

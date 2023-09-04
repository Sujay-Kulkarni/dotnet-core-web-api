using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_books.Interfaces;
using my_books.Models;
using my_books.Models.ViewModels;
using System.Collections.Generic;

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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Book>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult GetAllBooks()
        {
            var lstBooks = _service.GetAllBooks();
            if (lstBooks.Count > 0)
                return Ok(lstBooks);
            return NoContent();
        }

        [HttpGet("get-book-details-by-id/{bookId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Book))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetBookById(int bookId)
        {
            var objBook = _service.GetBookWithAuthor(bookId);
            if (objBook != null)
                return Ok(objBook);
            return NotFound();
        }


        [HttpPost("add-book")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(BookWithAuthorVM))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddBook([FromBody] BookVM bookVm)
        {
            var respons = _service.AddBook(bookVm);
            if (respons != null)
                return Created(nameof(AddBook), respons);
            return BadRequest();
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

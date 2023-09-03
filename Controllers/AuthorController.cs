using Microsoft.AspNetCore.Mvc;
using my_books.Interfaces;
using my_books.Models.ViewModels;
using System.Collections.Generic;

namespace my_books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private IAuthorService _service;
        public AuthorController(IAuthorService service)
        {
            _service = service;
        }

        [HttpPost("add-author")]
        public IActionResult AddAuthor([FromBody] AuthorVM authorVM)
        {
            _service.AddAuthor(authorVM);
            return Ok();
        }

        [HttpGet("get-all-authors")]
        public IActionResult GetAllAuthors()
        {
            List<Author> authors = _service.GetAllAuthor();
            return Ok(authors);
        }

        [HttpGet("get-author-by-id/{authorId}")]
        public IActionResult GetAuthorDetails(int authorId)
        {
            Author author = _service.GetAuthor(authorId);
            return Ok(author);
        }

        [HttpPut("update-author/{authorId}")]
        public IActionResult UpdateAuthor(int authorId, [FromBody] AuthorVM authorVM)
        {
            Author author = _service.UpdateAuthor(authorId, authorVM);
            return Ok(author);
        }

        [HttpDelete("delete-author/{authorId}")]
        public IActionResult DeleteAuthor(int authorId)
        {
            _service.DeleteAuthor(authorId);
            return Ok();
        }
    }
}

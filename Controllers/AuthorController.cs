using Microsoft.AspNetCore.Mvc;
using my_books.Exceptions;
using my_books.Interfaces;
using my_books.Models.ViewModels;
using System;
using System.Collections.Generic;

namespace my_books.Controllers
{
    [ApiVersion("1.0")]
    //[Route("api/[controller]")]
    [Route("api/v{version:apiversion}/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _service;
        public AuthorController(IAuthorService service)
        {
            _service = service;
        }

        [HttpPost("add-author")]
        public IActionResult AddAuthor([FromBody] AuthorVM authorVM)
        {
            try
            {
                _service.AddAuthor(authorVM);
                return Ok();
            }
            catch (InNotValidNameException ex)
            {
                return BadRequest($"{ex.Message}, Author Name: {ex.Name}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("get-all-authors")]
        //[Produces("application/xml")]
        public IActionResult GetAllAuthors()
        {
            List<Author> authors = _service.GetAllAuthor();
            return Ok(authors);
        }

        [HttpGet("get-author-by-id/{authorId}")]
        public IActionResult GetAuthorDetails(int authorId)
        {
            AuthorWithBookVM authorWithBook = _service.GetAuthorWithBook(authorId);
            return Ok(authorWithBook);
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

        //[HttpGet("get-author-details/{authorId}")]
        //public IActionResult GetAuthorDetails(int authorId)
        //{
        //    AuthorWithBookVM authorWithBook = _service.GetAuthorWithBook(authorId);
        //    return Ok(authorWithBook);
        //}
    }
}

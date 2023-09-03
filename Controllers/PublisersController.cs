using Microsoft.AspNetCore.Mvc;
using my_books.Interfaces;
using my_books.Models.ViewModels;

namespace my_books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisersController : ControllerBase
    {
        private readonly IPublisherService _service;
        public PublisersController(IPublisherService service)
        {
            _service = service;
        }

        [HttpPost("add-publisher")]
        public IActionResult AddPublisher([FromBody] PublisherVM publisherVM)
        {
            _service.AddPulisher(publisherVM);
            return Ok();
        }
    }
}

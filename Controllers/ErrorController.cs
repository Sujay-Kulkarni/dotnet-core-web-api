using Microsoft.AspNetCore.Mvc;

namespace my_books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ErrorController : ControllerBase
    {
        [HttpGet("error")]
        public IActionResult Error() => Problem();
    }
}

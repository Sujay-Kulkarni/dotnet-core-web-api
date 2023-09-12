using Microsoft.AspNetCore.Mvc;
using my_books.Exceptions;
using my_books.Interfaces;
using my_books.Models;
using my_books.Models.ViewModels;
using System;
using System.Collections.Generic;

namespace my_books.Controllers
{
    [ApiVersion("1.0")]
    //[Route("api/[controller]")]
    [Route("api/v{version:apiversion}/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private readonly IPublisherService _service;
        public PublishersController(IPublisherService service)
        {
            _service = service;
        }

        [HttpPost("add-publisher")]
        public IActionResult AddPublisher([FromBody] PublisherVM publisherVM)
        {
            try
            {
                _service.AddPulisher(publisherVM);
                return Ok();
            }
            catch (InNotValidNameException ex)
            {
                return BadRequest($"{ex.Message}, Publisher Name: {ex.Name}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("get-all-publishers")]
        public IActionResult GetAllPublishers(string sortBy)
        {
            List<Publisher> publishers = _service.GetAllPulishers(sortBy);
            return Ok(publishers);
        }

        [HttpGet("get-publisher-by-id/{publisherId}")]
        public IActionResult GetPublisherById(int publisherId)
        {
            Publisher publisher = _service.GetPublisher(publisherId);
            return Ok(publisher);
        }

        [HttpPut("update-publisher/{publisherId}")]
        public IActionResult UpdatePublisher(int publisherId, [FromBody] PublisherVM publisherVM)
        {
            Publisher publisher = _service.UpdatePublisher(publisherId, publisherVM);
            return Ok(publisher);
        }

        [HttpDelete("remove-publisher/{publisherId}")]
        public IActionResult DeletePublisher(int publisherId)
        {
            _service.DeletePublisher(publisherId);
            return Ok();
        }

        [HttpGet("get-publisher-details/{publisherId}")]
        public IActionResult GetPublisherDetails(int publisherId)
        {
            var pubDetails = _service.GetPublisherDetails(publisherId);
            return Ok(pubDetails);
        }
    }
}

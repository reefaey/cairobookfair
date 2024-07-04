using Cairo_book_fair.DTOs;
using Cairo_book_fair.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cairo_book_fair.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private readonly IPublisherService publisherService;

        public PublisherController(IPublisherService publisherService)
        {
            this.publisherService = publisherService;
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////

        [HttpGet("Paginated")]
        public IActionResult GetPaginatedPublisher(int pageNo, int pagesize)
        {
            return Ok(publisherService.GetPaginatedPublisher(pageNo, pagesize));
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////
        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            PublisherDto publisher = publisherService.Get(id);
            if (publisher != null)
            {
                return Ok(publisher);
            }
            return BadRequest();
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////

        [HttpPost]
        public IActionResult Insert(PublisherDtoForInsert publisher)
        {
            if (ModelState.IsValid == true)
            {
                publisherService.Insert(publisher);
                publisherService.Save();
                return Ok();
            }
            return BadRequest(ModelState);
        }
        ////////////////////////////////////////////////////////////////////////////////
        ///
        [HttpPut]
        public IActionResult Update(int id, PublisherDtoForInsert publisher)
        {
            if (ModelState.IsValid == true)
            {
                try
                {
                    publisherService.Update(id, publisher);
                    publisherService.Save();
                    return NoContent();
                }
                catch (KeyNotFoundException ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return BadRequest(ModelState);
        }
        //////////////////////////////////////////////////////////////////
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                publisherService.Delete(id);
                publisherService.Save();
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }

        }
        ///////////////////////////////////////////////////////////////////////////////
        [HttpGet("Search")]
        public IActionResult Search(String search)
        {
            List<PublisherDto> publishers = publisherService.Search(search);
            if (publishers != null)
            {
                return Ok(publishers);
            }
            return NotFound("No books found");
        }
    }
}

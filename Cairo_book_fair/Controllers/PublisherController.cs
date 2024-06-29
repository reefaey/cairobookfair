using Cairo_book_fair.Models;
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
        [HttpGet]
        public IActionResult GetAll(string? include = null)
        {
            List<Publisher> publishers = publisherService.GetAll(include);

            return Ok(publishers);
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            Publisher publisher = publisherService.Get(id);

            if (publisher != null)
            {
                return Ok(publisher);
            }

            return BadRequest();
        }

        [HttpPost]
        public IActionResult Insert(Publisher publisher)
        {
            if (ModelState.IsValid == true)
            {
                publisherService.Insert(publisher);

                publisherService.Save();

                return CreatedAtAction("Get", new { id = publisher.Id }, publisher);
            }

            return BadRequest(ModelState);
        }

        [HttpPut]
        public IActionResult Update(Publisher publisher)
        {
            if (ModelState.IsValid == true)
            {
                publisherService.Update(publisher);

                publisherService.Save();

                return NoContent();
            }

            return BadRequest(ModelState);
        }

        [HttpDelete]
        public IActionResult Delete(Publisher publisher)
        {
            publisherService.Delete(publisher);
            return NoContent();
        }
    }
}

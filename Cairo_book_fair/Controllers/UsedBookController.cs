using Cairo_book_fair.DTOs;
using Cairo_book_fair.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cairo_book_fair.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsedBookController : ControllerBase
    {
        private readonly IUsedBookService usedBookService;

        public UsedBookController(IUsedBookService usedBookService)
        {
            this.usedBookService = usedBookService;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////

        [HttpGet("Paginated")]
        public IActionResult GetPaginatedBooks(int pageNo, int pagesize, string[] includes = null)
        {
            return Ok(usedBookService.GetPaginatedBooks(pageNo, pagesize));
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////
        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            UsedBookDto book = usedBookService.Get(id);
            if (book != null)
            {
                return Ok(book);
            }
            return BadRequest();
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////

        [HttpPost]
        public IActionResult Insert(UsedBookForInsert bookDB)
        {
            if (ModelState.IsValid == true)
            {
                usedBookService.Insert(bookDB);
                usedBookService.Save();
                //return CreatedAtAction("Get", new { id = bookDB }, bookDB);
                return Ok(bookDB);
            }
            return BadRequest(ModelState);
        }
        ////////////////////////////////////////////////////////////////////////////////
        ///
        [HttpPut]
        public IActionResult Update(int id, UsedBookForInsert bookDB)
        {
            if (ModelState.IsValid == true)
            {
                usedBookService.Update(id, bookDB);
                usedBookService.Save();
                return Ok();
            }
            return BadRequest(ModelState);
        }
        //////////////////////////////////////////////////////////////////
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            usedBookService.Delete(id);
            usedBookService.Save();
            return NoContent();
        }
        ///////////////////////////////////////////////////////////////////////////////
        [HttpGet("Search")]
        public IActionResult Search(String search)
        {
            List<UsedBookDto> books = usedBookService.Search(search);
            if (books != null)
            {
                return Ok(books);
            }
            return NotFound("No books found");
        }



    }
}

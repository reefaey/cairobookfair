using Cairo_book_fair.Models;
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

        [HttpGet]
        public IActionResult GetAll(string[] includes = null)
        {
            List<UsedBook> books = usedBookService.GetAll(includes);
            if (books != null)
            {
                return Ok(books);
            }
            return BadRequest();
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////

        [HttpGet("Paginated")]
        public IActionResult GetPaginatedBooks(int pageNo, int pagesize, string[] includes = null)
        {
            return Ok(usedBookService.GetPaginatedBooks());
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////
        [HttpGet("{id:int}")]
        public IActionResult Get(int id, string[] include = null)
        {
            UsedBook book = usedBookService.Get(id, include);
            if (book != null)
            {
                return Ok(book);
            }
            return BadRequest();
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////

        [HttpPost]
        public IActionResult Insert(UsedBook bookDB)
        {
            if (ModelState.IsValid == true)
            {
                usedBookService.Insert(bookDB);
                usedBookService.Save();
                return CreatedAtAction("Get", new { id = bookDB.Id }, bookDB);
            }
            return BadRequest(ModelState);
        }
        ////////////////////////////////////////////////////////////////////////////////
        ///
        [HttpPut]
        public IActionResult Update(UsedBook bookDB)
        {
            if (ModelState.IsValid == true)
            {
                usedBookService.Update(bookDB);
                usedBookService.Save();
                return NoContent();
            }
            return BadRequest(ModelState);
        }
        //////////////////////////////////////////////////////////////////
        [HttpDelete]
        public IActionResult Delete(UsedBook book)
        {
            usedBookService.Delete(book);
            return NoContent();
        }
        ///////////////////////////////////////////////////////////////////////////////
        [HttpGet("Search")]
        public IActionResult Search(String search)
        {
            List<UsedBook> books = usedBookService.Search(search);
            if (books != null)
            {
                return Ok(books);
            }
            return NotFound("No books found");
        }



    }
}

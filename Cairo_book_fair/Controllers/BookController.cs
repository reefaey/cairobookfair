using AutoMapper;
using Cairo_book_fair.DTOs;
using Cairo_book_fair.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cairo_book_fair.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {

        private readonly IBookService bookService;
        private readonly IMapper mapper;

        public BookController(IBookService bookService, IMapper mapper)
        {

            this.bookService = bookService;
            this.mapper = mapper;
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////
        [HttpGet]
        public IActionResult GetAll(string[] includes = null)
        {
            List<BookWithDetails> books = bookService.GetAll(includes);
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
            return Ok(bookService.GetPaginatedBooks());
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////
        [HttpGet("{id:int}")]
        public IActionResult Get(int id, string[] include = null)
        {
            BookWithDetails book = bookService.Get(id, include);
            if (book != null)
            {
                return Ok(book);
            }
            return BadRequest();
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////

        [HttpPost]
        public IActionResult Insert(BookDTO book)
        {
            if (ModelState.IsValid == true)
            {
                bookService.Insert(book);
                bookService.Save();
                return CreatedAtAction("Get", new { id = book }, book);
            }
            return BadRequest(ModelState);
        }
        ////////////////////////////////////////////////////////////////////////////////
        ///
        [HttpPut]
        public IActionResult Update(int id, BookDTO book)
        {
            if (ModelState.IsValid == true)
            {
                try
                {
                    bookService.Update(id, book);
                    bookService.Save();
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
                bookService.Delete(id);
                bookService.Save();
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
            List<BookWithDetails> books = bookService.Search(search);
            if (books != null)
            {
                return Ok(books);
            }
            return NotFound("No books found");
        }


    }
}

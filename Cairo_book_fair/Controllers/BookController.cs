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

        [HttpGet("Paginated")]
        public IActionResult GetPaginatedBooks(int pageNo, int pagesize)
        {
            return Ok(bookService.GetPaginatedBooks(pageNo, pagesize));
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////

        [HttpGet("Paginated/UsedBook")]
        public IActionResult GetPaginatedUsedBooks(int pageNo, int pagesize)
        {
            return Ok(bookService.GetPaginatedUsedBooks(pageNo, pagesize));
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////
        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            BookWithDetails book = bookService.Get(id);
            if (book != null)
            {
                return Ok(book);
            }
            return BadRequest();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////
        [HttpGet("UsedBook/{id:int}")]
        public IActionResult GetUsedBook(int id)
        {
            UsedBookDtoGet book = bookService.GetUsedBook(id);
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
                return Ok();
            }
            return BadRequest(ModelState);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////

        [HttpPost("UsedBook")]
        public IActionResult InsertUsedBook(UsedBookDtoInsert book)
        {
            if (ModelState.IsValid == true)
            {
                bookService.InsertUsedBook(book);
                bookService.Save();
                return Ok();
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

        ////////////////////////////////////////////////////////////////////////////////
        ///
        [HttpPut("UsedBook")]
        public IActionResult UpdateUsedBook(int id, UsedBookDtoInsert book)
        {
            if (ModelState.IsValid == true)
            {
                try
                {
                    bookService.UpdateUsedBook(id, book);
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

        //////////////////////////////////////////////////////////////////
        [HttpDelete("UsedBook")]
        public IActionResult DeleteUsedBook(int id)
        {
            try
            {
                bookService.DeleteUsedBook(id);
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

        ///////////////////////////////////////////////////////////////////////////////
        [HttpGet("Search/UsedBook")]
        public IActionResult SearchUsedBook(String search)
        {
            List<UsedBookDtoGet> books = bookService.SearchUsedBook(search);
            if (books != null)
            {
                return Ok(books);
            }
            return NotFound("No books found");
        }


    }
}

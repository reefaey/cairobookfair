using AutoMapper;
using Cairo_book_fair.DTOs;
using Cairo_book_fair.Services;
using Microsoft.AspNetCore.Mvc;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;


namespace Cairo_book_fair.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {

        private readonly IBookService bookService;
        private readonly IMapper mapper;
        private readonly IHostingEnvironment hosting;

        public BookController(IBookService bookService, IMapper mapper, IHostingEnvironment hosting)
        {

            this.bookService = bookService;
            this.mapper = mapper;
            this.hosting = hosting;
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
                //if (book.ImageFile != null)
                //{
                //    string BookImageFolder = Path.Combine(hosting.WebRootPath, "BookImages");
                //    string ImagePath = Path.Combine(BookImageFolder, book.ImageFile.FileName);
                //    book.ImageFile.CopyTo(new FileStream(ImagePath, FileMode.Create));
                //    book.ImageUrl = book.ImageFile.FileName;
                //}

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
                //if (book.ImageFile != null)
                //{
                //    string UsedBookImageFolder = Path.Combine(hosting.WebRootPath, "UsedBookImages");
                //    string ImagePath = Path.Combine(UsedBookImageFolder, book.ImageFile.FileName);
                //    book.ImageFile.CopyTo(new FileStream(ImagePath, FileMode.Create));
                //    book.ImageUrl = book.ImageFile.FileName;
                //}
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
                //if (book.ImageFile != null)
                //{
                //    string BookImageFolder = Path.Combine(hosting.WebRootPath, "BookImages");
                //    string ImagePath = Path.Combine(BookImageFolder, book.ImageFile.FileName);
                //    book.ImageFile.CopyTo(new FileStream(ImagePath, FileMode.Create));
                //    book.ImageUrl = book.ImageFile.FileName;
                //}
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
                //if (book.ImageFile != null)
                //{
                //    string UsedBookImageFolder = Path.Combine(hosting.WebRootPath, "UsedBookImages");
                //    string ImagePath = Path.Combine(UsedBookImageFolder, book.ImageFile.FileName);
                //    book.ImageFile.CopyTo(new FileStream(ImagePath, FileMode.Create));
                //    book.ImageUrl = book.ImageFile.FileName;
                //}
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
        /////////////////////////////////////////////////////////////////////////////////
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

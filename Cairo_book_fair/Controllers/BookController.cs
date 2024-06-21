using AutoMapper;
using Cairo_book_fair.DTOs;
using Cairo_book_fair.Models;
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

        BookController(IBookService bookService, IMapper mapper)
        {

            this.bookService = bookService;
            this.mapper = mapper;
        }
        ///////////////////////////////////////////////////////////////////////////
        [HttpGet]
        public IActionResult GetAll(int pageNo, int pagesize, string[] includes = null)
        {
            List<Book> books = bookService.GetAll();
            if (books != null)
            {
                var booksDTO = mapper.Map<IEnumerable<BookWithDetails>>(books);
                return Ok(booksDTO);
            }

            //pagination//
            int NoOfRecordsPerPage = 5;
            int NoOfPages = (int)Math.Ceiling(books.Count / (double)NoOfRecordsPerPage);
            int NoOfRecordsToSkip = (pageNo - 1) * NoOfRecordsPerPage;
            books = books.Skip(NoOfRecordsToSkip).Take(NoOfRecordsPerPage).ToList();


            return BadRequest();
        }

        ///////////////////////////////////////////////////////////////////////////
        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            Book bookDB = bookService.Get(id);

            if (bookDB != null)
            {
                BookWithDetails bookDTO = mapper.Map<BookWithDetails>(bookDB);

                //bookDTO.BookName = bookDB.Name;
                ///////////bookDTO.AuthorName = bookDB.Author.Name;
                ////////////bookDTO.BlockName = bookDB.Publisher.Block.Name;
                //bookDTO.PagesNumber = bookDB.PagesNumber;
                //bookDTO.SoundBook = bookDB.SoundBook;
                //bookDTO.PublishingYear = bookDB.PublishingYear;
                //bookDTO.ImageUrl = bookDB.ImageUrl;
                /////////////bookDTO.HallNumber = bookDB.Publisher.Block.Hall.Id;
                /////////////bookDTO.CategoryNames = bookDB.Categories.Select(c => c.Name).ToList();

                return Ok(bookDTO);
            }
            return BadRequest();
        }
        /////////////////////////////////////////////////////////////////////////////////





        //////////////////////////////////////////////////////////////////////////////////

        [HttpPost]
        public IActionResult Insert(Book bookDB)
        {
            if (ModelState.IsValid == true)
            {
                bookService.Insert(bookDB);
                bookService.Save();
                return CreatedAtAction("Get", new { id = bookDB.Id }, bookDB);
            }
            return BadRequest(ModelState);
        }
        ////////////////////////////////////////////////////////////////////////////////
        ///
        [HttpPut]
        public IActionResult Update(Book bookDB)
        {
            if (ModelState.IsValid == true)
            {
                bookService.Update(bookDB);
                bookService.Save();
                return NoContent();
            }
            return BadRequest(ModelState);
        }
        //////////////////////////////////////////////////////////////////
        [HttpDelete]
        public IActionResult Delete(Book book)
        {
            bookService.Delete(book);
            return NoContent();
        }


    }
}

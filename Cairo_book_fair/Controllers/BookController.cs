using Cairo_book_fair.DTOs;
using Cairo_book_fair.Models;
using Cairo_book_fair.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Cairo_book_fair.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository bookRepository;

        BookController(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }
        ///////////////////////////////////////////////////////////////////////////
        [HttpGet]
        public IActionResult GetAll(string[] includes = null)
        {
            List<Book> books = bookRepository.GetAll();
            return Ok(books);
        }
        ////////////////////////////////////////////////////////////////////////////
        [HttpGet("All")]
        public IActionResult Get(Func<Book, bool> where)
        {
            List<Book> books = bookRepository.Get(where);

            return Ok(books);
        }
        ///////////////////////////////////////////////////////////////////////////
        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            Book bookDB = bookRepository.Get(id);
            BookWithDetails bookDTO = new BookWithDetails();

            if (bookDB != null)
            {
                bookDTO.BookName = bookDB.Name;
                bookDTO.AuthorName = bookDB.Author.Name;
                bookDTO.BlockName = bookDB.Publisher.Block.Name;
                bookDTO.PagesNumber = bookDB.PagesNumber;
                bookDTO.SoundBook = bookDB.SoundBook;
                bookDTO.PublishingYear = bookDB.PublishingYear;
                bookDTO.ImageUrl = bookDB.ImageUrl;
                bookDTO.HallNumber = bookDB.Publisher.Block.Hall.Id;
                bookDTO.CategoryNames = bookDB.Categories.Select(c => c.Name).ToList();

                return Ok(bookDTO);
            }
            return BadRequest();
        }
        //////////////////////////////////////////////////////////////////////////////////
        ///
        [HttpPost]
        public IActionResult Insert(Book bookDB)
        {
            if (ModelState.IsValid == true)
            {
                bookRepository.Insert(bookDB);
                bookRepository.Save();
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
                bookRepository.Update(bookDB);
                bookRepository.Save();
                return NoContent();
            }
            return BadRequest(ModelState);
        }
        [HttpDelete]
        public IActionResult Delete(Book book)
        {
            bookRepository.Delete(book);
            return NoContent();
        }


    }
}

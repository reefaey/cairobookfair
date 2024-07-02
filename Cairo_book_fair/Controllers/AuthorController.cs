using Cairo_book_fair.DTOs;
using Cairo_book_fair.Models;
using Cairo_book_fair.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace Cairo_book_fair.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        public IActionResult GetAuthors()
        {
            List<AuthorDTO> authorDTOs = _authorService.GetAllDTO();
            return Ok(authorDTOs);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetAuthorById(int id)
        {
            AuthorDTO author = _authorService.Get(id);
            return Ok(author);

        }

        [HttpPost]
        public IActionResult InsertAuthor(AuthorDTO authorDto)
        {
            if (ModelState.IsValid)
            {
                Author author = new();
                author = _authorService.MappingFromAuthorDtoToAuthor(authorDto, author);
                _authorService.Insert(author);
                _authorService.Save();

                return CreatedAtAction(nameof(GetAuthorById), new { id = author.Id }, authorDto);

            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        public IActionResult UpdateAuthor(int id, AuthorDTO authorDto)
        {
            Author author = _authorService.GetById(id);
            if (author != null)
            {
                _authorService.Update(id, authorDto);
                return NoContent();
            }
            return BadRequest("Invalid ID");
        }

        [HttpDelete]
        public IActionResult DeleteAuthor(int id)
        {
            try
            {
                _authorService.Delete(id);
                _authorService.Save();

                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("Pagenation")]
        public IActionResult Get(int page, int pageSize)
        {
            return Ok(_authorService.GetPaginatedAuthor(page, pageSize));
        }

        //[HttpPost("InsertBook")]
        //public IActionResult InsertBook(BookDetailsWithAuthorId bookDetailsWithAuthorId)
        //{
        //    if(ModelState.IsValid)
        //    {

        //    }
        //}
    }
}

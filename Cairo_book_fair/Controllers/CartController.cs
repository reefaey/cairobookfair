using Cairo_book_fair.DTOs;
using Cairo_book_fair.Models;
using Cairo_book_fair.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Cairo_book_fair.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly IBookCartService _bookCartService;
        
        public CartController(IBookCartService bookCartService)
        {
            _bookCartService = bookCartService;
        }

        //[HttpGet("All")]
        //public IActionResult GetAllItems()
        //{

        //}

        //[HttpGet]
        //public IActionResult GetBookNamewithUserName()
        //{

        //}

        [HttpPost]
        public IActionResult InserItem(BookItemWithUserID bookItemWithUserID)
        {
            if(ModelState.IsValid)
            {
                _bookCartService.AddItem(bookItemWithUserID.userId, bookItemWithUserID.bookId);
                _bookCartService.Save();

                return Ok(bookItemWithUserID);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete]
        public IActionResult Delete(BookItemWithUserID bookItemWithUserID)
        {
            if (ModelState.IsValid)
            {
                _bookCartService.RemoveItem(bookItemWithUserID.userId, bookItemWithUserID.bookId);
                _bookCartService.Save();
                return NoContent();
            }

            return BadRequest(ModelState);          

        }


    }
}

using Cairo_book_fair.Models;
using Cairo_book_fair.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        //[HttpPost]
        //public IActionResult InserItem(int userId, int bookId)
        //{
        //    _bookCartService.FindCartId()
        //    BookCart bookCart = new();

        //}
    }
}

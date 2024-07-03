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
        private readonly ICartService _cartService;
        
        public CartController(IBookCartService bookCartService, ICartService cartService)
        {
            _bookCartService = bookCartService;
            _cartService = cartService;
        }

        [HttpGet("All")]
        public IActionResult GetAllItems(int cartId)
        {
            List<CartItemDTO> cartItemsDto = _bookCartService.GetAllCartItems(cartId);

            if(cartItemsDto == null)
            {
                return BadRequest();
            }

            return Ok(cartItemsDto);
        }

        //[HttpGet]
        //public IActionResult GetBookNamewithUserName()
        //{

        //}

        [HttpPost ("Buy Regular Book")]
        public IActionResult InserItem(BookItemWithUserID bookItemWithUserID)
        {
            if(ModelState.IsValid)
            {
                 Cart cart = _cartService.GetCartByUserId(bookItemWithUserID.userId);
                _bookCartService.AddItem(cart.Id, bookItemWithUserID.bookId);
                _bookCartService.Save();

                return Ok("!تمت اضافة الكتاب إلى السلة بنجاح");
            }
            return BadRequest("عذراً لم يتم اضافة الكتاب إلى السلة");
        }

        [HttpPost("Take Donated Book")]
        public IActionResult TakeBook(BookItemWithUserID bookItemWithUserID)
        {
            if (ModelState.IsValid)
            {
                Cart cart = _cartService.GetCartByUserId(bookItemWithUserID.userId);
                _bookCartService.AddItem(cart.Id, bookItemWithUserID.bookId);
                _bookCartService.Save();

                return Ok("!تمت اضافة الكتاب إلى السلة بنجاح");
            }
            return BadRequest("عذراً لم يتم اضافة الكتاب إلى السلة");
        }

        [HttpDelete]
        public IActionResult Delete(BookItemWithUserID bookItemWithUserID)
        {
            if (ModelState.IsValid)
            {
                Cart cart = _cartService.GetCartByUserId(bookItemWithUserID.userId);
                _bookCartService.RemoveItem(cart.Id, bookItemWithUserID.bookId);
                _bookCartService.Save();
                return NoContent();
            }

            return BadRequest(ModelState);          

        }

        [HttpPut("Change Quantity")]
        public IActionResult ChangeQuantity(int quantity, BookItemWithUserID bookItemWithUserID)
        {
            if (ModelState.IsValid)
            {
                Cart cart = _cartService.GetCartByUserId(bookItemWithUserID.userId);
                _bookCartService.RemoveItem(cart.Id, bookItemWithUserID.bookId);
                _bookCartService.Save();
                return NoContent();
            }

            return BadRequest(ModelState);

        }


    }
}

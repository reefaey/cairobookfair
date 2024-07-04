using Cairo_book_fair.DTOs;
using Cairo_book_fair.Models;
using Cairo_book_fair.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Claims;

namespace Cairo_book_fair.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly IBookCartService _bookCartService;
        private readonly ICartService _cartService;
        private readonly UserManager<User> _userManager;

        public CartController(IBookCartService bookCartService, ICartService cartService, UserManager<User> userManager)
        {
            _bookCartService = bookCartService;
            _cartService = cartService;
            _userManager = userManager;
        }
        [HttpGet("All")]
        public IActionResult GetAllItems(string UserId)
        {
            if(UserId == User.FindFirstValue(ClaimTypes.NameIdentifier)) 
            {
                Cart cart = _cartService.GetCartByUserId(UserId);
                WholeCartItemsWithTotalPriceDTO Cart = _bookCartService.GetCartBooks(cart.Id);

                if(Cart.cartItems.Count == 0)
                {
                    return BadRequest("!نأسف لعدم وجود اي كتاب في السلة .. اشتري الآن");
                }

                return Ok(Cart);
            }

            return Unauthorized("عذراً هذا الحساب ليس له صلاحية الوصول للسلة");
        }

        //[HttpGet]
        //public IActionResult GetBookNamewithUserName()
        //{

        //}
        [HttpPost ("Buy-Regular-Book")]
        public IActionResult InserItem(BookItemWithUserID bookItemWithUserID)
        {
            if(ModelState.IsValid && bookItemWithUserID.userId == User.FindFirstValue(ClaimTypes.NameIdentifier))
            {
                 Cart cart = _cartService.GetCartByUserId(bookItemWithUserID.userId);
                _bookCartService.AddBook(cart.Id, bookItemWithUserID.bookId);
                _bookCartService.Save();

                return Ok("!تمت اضافة الكتاب إلى السلة بنجاح");
            }
            return BadRequest("عذراً لم يتم اضافة الكتاب إلى السلة");
        }
        [HttpPost("Take-Donated-Book")]
        public async Task<IActionResult> TakeBook(BookItemWithUserID bookItemWithUserID)
        {
            if (ModelState.IsValid && bookItemWithUserID.userId == User.FindFirstValue(ClaimTypes.NameIdentifier))
            {
                Cart cart = _cartService.GetCartByUserId(bookItemWithUserID.userId);
                //Use UserManager.GetUserAsync(User) to get the currently authenticated user.
                //Use UserManager.FindByIdAsync(id) to get a user by their ID.

                User user = await _userManager.GetUserAsync(User);
                if (user.NumberOfDonatedBooks > user.NumberOfTakedBooks)
                {
                    _bookCartService.AddDonatedBook(cart.Id, bookItemWithUserID.bookId);
                    _bookCartService.Save();

                    return Ok("!تمت اضافة الكتاب إلى السلة بنجاح");
                }
            }
            return BadRequest("عذراً لم يتم اضافة الكتاب إلى السلة ربما تخطيت العدد المسموح لك بأخذ كتب التبرع");
        }
        
        [HttpDelete("Remove-item-from-Cart")]
        public IActionResult Delete(BookItemWithUserID bookItemWithUserID)
        {
            if (ModelState.IsValid && bookItemWithUserID.userId == User.FindFirstValue(ClaimTypes.NameIdentifier))
            {
                Cart cart = _cartService.GetCartByUserId(bookItemWithUserID.userId);
                _bookCartService.RemoveItem(cart.Id, bookItemWithUserID.bookId);
                _bookCartService.Save();
                return Ok("!تمت ازالة الكتاب بنجاح");
            }

            return BadRequest("عذراً لم تتم عملية الازالة");

        }

        [HttpPut("Change Quantity")]
        public IActionResult ChangeQuantity(int quantity, BookItemWithUserID bookItemWithUserID)
        {
            if (ModelState.IsValid && bookItemWithUserID.userId == User.FindFirstValue(ClaimTypes.NameIdentifier))

            {
                Cart cart = _cartService.GetCartByUserId(bookItemWithUserID.userId);
                _bookCartService.RemoveItem(cart.Id, bookItemWithUserID.bookId);
                _bookCartService.Save();
                return Ok("!تم تعديل الكمية بنجاح");
            }

            return BadRequest("عذراً لم تتم عملية التعديل");

        }


    }
}

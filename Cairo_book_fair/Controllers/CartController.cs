using Cairo_book_fair.DTOs;
using Cairo_book_fair.Models;
using Cairo_book_fair.Repositories;
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
        private readonly IBookRepository _bookRepository;
        private readonly UserManager<User> _userManager;

        public CartController(IBookCartService bookCartService, ICartService cartService, UserManager<User> userManager, IBookRepository bookRepository)
        {
            _bookCartService = bookCartService;
            _cartService = cartService;
            _userManager = userManager;
            _bookRepository = bookRepository;
        }

        [HttpGet("All")]
        public IActionResult GetAllItems()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Cart cart = _cartService.GetCartByUserId(userId);
            WholeCartItemsWithTotalPriceDTO? cartItems = _bookCartService.GetAllCartItems(cart.Id);

            if(cartItems == null)
            {
                return Ok("!نأسف لعدم وجود اي كتاب في السلة .. اشتري الآن");
            }

            return Ok(cartItems);
            //return Unauthorized("عذراً هذا الحساب ليس له صلاحية الوصول للسلة");
        }

        [HttpPut]
        public IActionResult ChangeTheQuantity(BookIdDTO bookIdDto, int quantity)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Cart cart = _cartService.GetCartByUserId(userId);
            Book? book = _bookCartService.GetBook(bookIdDto.bookId);

            if (_bookCartService.IsBookAdded(cart.Id, book.Id))
            {
                if(book.IsAvailableForDonation == false)
                {
                    _bookCartService.ChangeQuantity(cart, book, quantity);
                    return Ok("تم تعديل الكمية بنجاح");   
                }
                return Ok("لا يمكن تعديل كمية الكتب المستعملة من قبل");
            }
            return Ok("عذراً هذا الكتاب غير موجود في السلة مسبقاً");
        }

        [HttpPost("Buy-Regular-Book")]
        public IActionResult InserItem(BookIdDTO bookItemWithUserID)
        {
            Book? book = _bookCartService.GetBook(bookItemWithUserID.bookId);
            if (book != null)
            {
                
                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                Cart cart = _cartService.GetCartByUserId(userId);
                _bookCartService.AddItem(cart, book);

                _bookCartService.Save();

                return Ok("!تمت اضافة الكتاب إلى السلة بنجاح");
            }
            return BadRequest("عذراً لم يتم اضافة الكتاب إلى السلة");
        }
        #region takeDonatedBook
        //[HttpPost("Take-Donated-Book")]
        //public IActionResult TakeBook(BookIdDTO bookItemWithUserID)
        //{
        //    Book? book = _bookCartService.GetBook(bookItemWithUserID.bookId);
        //    if(book != null)
        //    {
        //        string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        //        Cart cart = _cartService.GetCartByUserId(userId);
        //        _bookCartService.AddItem(cart, book);
        //        _bookCartService.Save();

        //        return Ok("!تمت اضافة الكتاب إلى السلة بنجاح");
        //    }
        //    return BadRequest("عذراً لم يتم اضافة الكتاب إلى السلة");
        //}

        //[HttpPost("Take-Donated-Book")]
        //public async Task<IActionResult> TakeBook(BookItemWithUserID bookItemWithUserID)
        //{
        //    if (ModelState.IsValid)
        //        if (ModelState.IsValid && bookItemWithUserID.userId == User.FindFirstValue(ClaimTypes.NameIdentifier))
        //        {
        //            Cart cart = _cartService.GetCartByUserId(bookItemWithUserID.userId);
        //            _bookCartService.AddItem(cart.Id, bookItemWithUserID.bookId);
        //            _bookCartService.Save();
        //            //Use UserManager.GetUserAsync(User) to get the currently authenticated user.
        //            //Use UserManager.FindByIdAsync(id) to get a user by their ID.

        //            return Ok("!تمت اضافة الكتاب إلى السلة بنجاح");
        //            User user = await _userManager.GetUserAsync(User);
        //            if (user.NumberOfDonatedBooks > user.NumberOfTakedBooks)
        //            {
        //                _bookCartService.AddDonatedBook(cart.Id, bookItemWithUserID.bookId);
        //                _bookCartService.Save();

        //                return Ok("!تمت اضافة الكتاب إلى السلة بنجاح");
        //            }
        //        }
        //        return BadRequest("عذراً لم يتم اضافة الكتاب إلى السلة ربما تخطيت العدد المسموح لك بأخذ كتب التبرع");
        //} 
        #endregion

        [HttpDelete("Remove-item-from-Cart")]
        public IActionResult Delete(BookIdDTO bookItemWithUserID)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            Book? book = _bookCartService.GetBook(bookItemWithUserID.bookId);
            Cart cart = _cartService.GetCartByUserId(userId);
            if(_bookCartService.IsBookAdded(cart.Id,book.Id))
            {
                _bookCartService.RemoveItem(cart, book);
                _bookCartService.Save();
                return Ok("!تمت ازالة الكتاب بنجاح");
            }

            return BadRequest("عذراً لم تتم عملية الازالة");

        }

        [HttpDelete("Remove-All-items-from-Cart")]
        public async Task<IActionResult> RemoveAllCartItems()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Cart cart = _cartService.GetCartByUserId(userId);
            await _bookCartService.RemoveAllCartItems(cart);
            //_bookCartService.Save();
            return Ok("!تم ازالة جميع الكتب بنجاح");
        }
    }
}

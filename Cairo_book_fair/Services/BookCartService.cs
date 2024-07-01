using Cairo_book_fair.DTOs;
using Cairo_book_fair.Models;
using Cairo_book_fair.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Internal;
using System.Collections.Generic;

namespace Cairo_book_fair.Services
{
    public class BookCartService : IBookCartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly IBookCartRepository _bookCartRepository;
        private readonly IBookService _bookService;
        private readonly UserManager<User> _userManager;

        public BookCartService(IBookCartRepository bookCartRepository, UserManager<User> userManager, IBookService bookService)
        {
            this._bookCartRepository = bookCartRepository;
            this._userManager = userManager;
            this._bookService = bookService;
        }

        public void AddItem(int cartId, int bookId)
        {
            BookCart bookCart = new()
            {
                CartId = cartId,
                BookId = bookId,
                Quantity = 1
            };
            _bookCartRepository.Insert(bookCart);
            
        }

        public BookCart GetBookCart(int cartId, int bookId)
        {
            return _bookCartRepository.GetBookCart(cartId, bookId);
        }

        public List<CartItemDTO> GetAllCartItems(int cartId)
        {
            //var cartItems = _bookCartRepository.GetAllBooksInCart(cartId)
            //    .Select(cartItem => new CartItemDTO
            //    { 
            //        BookId = cartItem.BookId,
            //        Quantity = cartItem.Quantity,
            //        Name= "csarsa",
            //        Image= "dsadsad"
            //    }).ToList();
            List<BookCart> cartItems = _bookCartRepository.GetAllBooksInCart(cartId);

            List<CartItemDTO> cartItemsDto = new List<CartItemDTO>();
            foreach (BookCart cartItem in cartItems)
            {

                BookWithDetails book = _bookService.Get(cartItem.BookId);
                cartItemsDto.Add( new CartItemDTO()
                {
                    BookId = cartItem.BookId,
                    Name = book.BookName,
                    Image = book.ImageUrl,
                    Quantity = cartItem.Quantity
                });

            }
            return cartItemsDto;

        }

        public void RemoveItem(int cartId, int bookId)
        {
            BookCart bookCart = _bookCartRepository.GetBookCart(cartId, bookId);
            _bookCartRepository.Delete(bookCart);
            
        }

        public void ChangeQuantity(string userId, int bookId, int quantity)
        {
            Cart cart = _cartRepository.GetCartByUserId(userId);
            BookCart bookCart = _bookCartRepository.GetBookCart(cart.Id, bookId);

            bookCart.Quantity= quantity;
            _bookCartRepository.Update(bookCart);
            _bookCartRepository.Save();
        }

        public void Save()
        {
            _bookCartRepository.Save();
        }


    }
}

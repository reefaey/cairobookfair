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
        private readonly IBookRepository _bookRepository;
        private readonly UserManager<User> _userManager;

        public BookCartService(IBookCartRepository bookCartRepository, UserManager<User> userManager, IBookRepository bookRepository)
        {
            this._bookCartRepository = bookCartRepository;
            this._userManager = userManager;
            this._bookRepository = bookRepository;
        }

        public void AddItem(int cartId, int bookId)
        {
            //search First in BookCart Table to check if this user added same book and increase its quantity rather than new by if condition
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

        public WholeCartItemsWithTotalPriceDTO GetAllCartItems(int cartId)
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

            WholeCartItemsWithTotalPriceDTO wholeCartItemsWithTotalPriceDTO = new() 
            { 
                cartItems = new List<CartItemDTO>()
            };

            foreach (BookCart cartItem in cartItems)
            {
                Book book = _bookRepository.Get(cartItem.BookId);
                wholeCartItemsWithTotalPriceDTO.cartItems
                    .Add( new CartItemDTO()
                    {
                        BookId = cartItem.BookId,
                        Name = book.Name,
                        Image = book.ImageUrl,
                        Quantity = cartItem.Quantity,
                        Price = book.Price
                    });
                wholeCartItemsWithTotalPriceDTO.totalPrice += book.Price;
            }
            return wholeCartItemsWithTotalPriceDTO;

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

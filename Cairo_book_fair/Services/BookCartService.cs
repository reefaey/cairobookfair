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

        public BookCartService(IBookCartRepository bookCartRepository, UserManager<User> userManager, IBookRepository bookRepository, ICartRepository cartRepository)
        {
            this._bookCartRepository = bookCartRepository;
            this._userManager = userManager;
            this._bookRepository = bookRepository;
            this._cartRepository = cartRepository;
        }

        public bool IsBookAdded(int cartId,int bookId)
        {
            return _bookCartRepository.IsBookAdded(cartId, bookId) != null ? true : false;
        }
        public void AddItem(Cart cart, Book book)
        {
            BookCart bookcart;
            //search First in BookCart Table to check if this user added same book and increase its quantity rather than new by if condition
            if (_bookCartRepository.IsBookAdded(cart.Id, book.Id))
            {
                bookcart = _bookCartRepository.GetBookCart(cart.Id, book.Id);
                if (bookcart != null)
                {
                    bookcart.Quantity++;
                }
                _bookCartRepository.Update(bookcart);
            }
            else
            {
                bookcart = new()
                {
                    CartId = cart.Id,
                    BookId = book.Id,
                    Quantity = 1
                };

                _bookCartRepository.Insert(bookcart);
            }
            cart.TotalCost += book.Price * bookcart.Quantity;
            _cartRepository.Update(cart);
            _cartRepository.Save();
        }

        public BookCart GetBookCart(int cartId, int bookId)
        {
            return _bookCartRepository.GetBookCart(cartId, bookId);
        }

        public WholeCartItemsWithTotalPriceDTO? GetAllCartItems(int cartId)
        {
            #region OldCode
            //var cartItems = _bookCartRepository.GetAllBooksInCart(cartId)
            //    .Select(cartItem => new CartItemDTO
            //    { 
            //        BookId = cartItem.BookId,
            //        Quantity = cartItem.Quantity,
            //        Name= "csarsa",
            //        Image= "dsadsad"
            //    }).ToList(); 
            #endregion
            List<BookCart>? cartItems = _bookCartRepository.GetAllBooksInCart(cartId);
            if (cartItems != null)
            {
                WholeCartItemsWithTotalPriceDTO wholeCartItemsWithTotalPriceDTO = new()
                {
                    cartItems = new List<CartItemDTO>()
                };

                foreach (BookCart cartItem in cartItems)
                {
                    Book book = _bookRepository.Get(cartItem.BookId);
                    wholeCartItemsWithTotalPriceDTO.cartItems
                        .Add(new CartItemDTO()
                        {
                            BookId = cartItem.BookId,
                            Name = book.Name,
                            Image = book.ImageUrl,
                            Quantity = cartItem.Quantity,
                            Price = book.Price
                        });
                    if (cartItem.Quantity != 0)
                    {
                        wholeCartItemsWithTotalPriceDTO.totalPrice += book.Price * cartItem.Quantity;
                    }
                }

                return wholeCartItemsWithTotalPriceDTO;
            }
            return null;
        }

        public void RemoveItem(Cart cart, Book book)
        {
            BookCart bookcart;
            bookcart = _bookCartRepository.GetBookCart(cart.Id, book.Id);
            if (bookcart != null)
            {
                cart.TotalCost -= book.Price * bookcart.Quantity;
                _cartRepository.Update(cart);
                _cartRepository.Save();
                _bookCartRepository.Delete(bookcart);
            }
        }

        public void ChangeQuantity(Cart cart, int bookId, int quantity)
        {
            BookCart bookCart = _bookCartRepository.GetBookCart(cart.Id, bookId);

            if (bookCart != null)
            {
                Book? book = _bookRepository.Get(bookId);

                if(quantity < bookCart.Quantity)
                {
                    cart.TotalCost -= book.Price * bookCart.Quantity;
                }
                else
                {
                    cart.TotalCost += book.Price * bookCart.Quantity;
                }
                _cartRepository.Update(cart);
                _cartRepository.Save();

                bookCart.Quantity = quantity;
                _bookCartRepository.Update(bookCart);
            }
        }

        public async Task RemoveAllCartItems(Cart cart)
        {
           await _bookCartRepository.RemoveAllCartItemsAsync(cart.Id);
            cart.TotalCost = 0;
            _cartRepository.Update(cart);
            _cartRepository.Save();
        }

        public void Save()
        {
            _bookCartRepository.Save();
        }

    }
}

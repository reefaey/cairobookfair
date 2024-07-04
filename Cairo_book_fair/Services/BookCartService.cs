using Cairo_book_fair.DTOs;
using Cairo_book_fair.Models;
using Cairo_book_fair.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Internal;
using System.Collections.Generic;
using System.Net;

namespace Cairo_book_fair.Services
{
    public class BookCartService : IBookCartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly IBookCartRepository _bookCartRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IUsedBookRepository _usedBookRepository;
        private readonly UserManager<User> _userManager;

        public BookCartService(IBookCartRepository bookCartRepository, UserManager<User> userManager, IBookRepository bookRepository, IUsedBookRepository usedBookRepository)
        {
            this._bookCartRepository = bookCartRepository;
            this._userManager = userManager;
            this._bookRepository = bookRepository;
            _usedBookRepository = usedBookRepository;
        }

        public void AddBook(int cartId, int bookId)
        {
            if(_bookCartRepository.IsBookAdded(cartId, bookId))
            {
                BookCart bookcart = _bookCartRepository.GetBookCart(cartId, bookId);
                if (bookcart != null)
                {
                    bookcart.Quantity++;
                }
            }
            BookCart bookCart = new()
            {
                CartId = cartId,
                BookId = bookId,
                Quantity = 1
            };
            _bookCartRepository.Insert(bookCart);
            
        }

        public void AddDonatedBook(int cartId, int bookId)
        {
            UsedBook? usedBook = _usedBookRepository.Get(bookId);

            if (usedBook != null)
            {
                BookCart bookCart = new()
                {
                    CartId = cartId,
                    DonatedBookId = bookId,
                    Quantity = 1
                };
                _bookCartRepository.Insert(bookCart);
                _usedBookRepository.Delete(usedBook);
            }
        }   

        public BookCart GetBookCart(int cartId, int bookId)
        {
            return _bookCartRepository.GetBookCart(cartId, bookId);
        }

        public WholeCartItemsWithTotalPriceDTO GetCartBooks(int cartId)
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
                if(cartItem.BookId != null)
                {
                    Book? book = _bookRepository.Get(cartItem.BookId);
                
                
                    if(book != null)
                    {
                        wholeCartItemsWithTotalPriceDTO.cartItems
                        .Add(new CartItemDTO()
                        {
                            BookId = cartItem.BookId,
                            Name = book.Name,
                            Image = book.ImageUrl,
                            Quantity = cartItem.Quantity,
                            Price = book.Price
                        });
                        wholeCartItemsWithTotalPriceDTO.totalPrice += book.Price;
                    }
                }
                UsedBook? usedBook = _usedBookRepository.Get(cartItem.BookId);
                if (usedBook != null)
                {
                    wholeCartItemsWithTotalPriceDTO.cartItems
                    .Add(new CartItemDTO()
                    {
                        DonatedBookId = cartItem.BookId,
                        Name = usedBook.BookName,
                        Image = usedBook.ImageURL,
                        Quantity = 1,
                        Price = 0
                    });
                }
                    
            }
            return wholeCartItemsWithTotalPriceDTO;
        }

        public void RemoveItem(int cartId, int bookId)
        {
            BookCart bookCart = _bookCartRepository.GetBookCart(cartId, bookId);
            if (bookCart != null)
            {
                _bookCartRepository.Delete(bookCart);
            }
        }

        public void ChangeQuantity(string userId, int bookId, int quantity)
        {
            Cart cart = _cartRepository.GetCartByUserId(userId);
            BookCart bookCart = _bookCartRepository.GetBookCart(cart.Id, bookId);

            if (bookCart != null)
            {
                bookCart.Quantity= quantity;
                _bookCartRepository.Update(bookCart);
                _bookCartRepository.Save();
            }
        }

        public void Save()
        {
            _bookCartRepository.Save();
        }


    }
}

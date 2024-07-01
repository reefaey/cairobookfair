using Cairo_book_fair.Models;
using Cairo_book_fair.Repositories;
using Microsoft.AspNetCore.Identity;

namespace Cairo_book_fair.Services
{
    public class BookCartService : IBookCartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly IBookCartRepository _bookCartRepository;
        private readonly UserManager<User> _userManager;

        public BookCartService(IBookCartRepository bookCartRepository, UserManager<User> userManager)
        {
            this._bookCartRepository = bookCartRepository;
            this._userManager = userManager;
        }

        public void AddItem(string userId, int bookId)
        {
            Cart cart = _cartRepository.GetCartByUserId(userId);
            BookCart bookCart = new()
            {
                CartId = cart.Id,
                BookId = bookId,
                Quantity = 1
            };
            _bookCartRepository.Insert(bookCart);
            
        }


        public void RemoveItem(string userId, int bookId)
        {
            Cart cart = _cartRepository.GetCartByUserId(userId);
            BookCart bookCart = _bookCartRepository.GetBookCart(cart.Id, bookId);
            _bookCartRepository.Delete(bookCart);
            
        }

        public void Save()
        {
            _bookCartRepository.Save();
        }


    }
}

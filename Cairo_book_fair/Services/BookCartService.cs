using Cairo_book_fair.Models;
using Cairo_book_fair.Repositories;
using Microsoft.AspNetCore.Identity;

namespace Cairo_book_fair.Services
{
    public class BookCartService : IBookCartService
    {
        private readonly IBookCartRepository repository;
        private readonly UserManager<User> _userManager;

        public BookCartService(IBookCartRepository bookCartRepository, UserManager<User> userManager)
        {
            this.repository = bookCartRepository;
            this._userManager = userManager;
        }

        //public async Task<int> FindCartId(string userId)
        //{
        //    User? userDb = await _userManager.FindByIdAsync(userId);
        //    return userDb != null ? userDb.CartId : -1;
        //}

        //public void AddItem(int cartId, int bookId)
        //{
        //    repository.
        //}
    }
}

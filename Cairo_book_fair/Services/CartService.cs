using Cairo_book_fair.Models;
using Cairo_book_fair.Repositories;

namespace Cairo_book_fair.Services
{
    public class CartService : Service<Cart>, ICartService
    {
        public CartService(IRepository<Cart> repository) : base(repository)
        {
        }
    }
}

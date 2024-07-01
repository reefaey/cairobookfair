using Cairo_book_fair.DBContext;
using Cairo_book_fair.Models;

namespace Cairo_book_fair.Repositories
{
    public interface ICartRepository : IRepository<Cart>
    {
        public Cart GetCartByUserId(string userId); 
    }
}

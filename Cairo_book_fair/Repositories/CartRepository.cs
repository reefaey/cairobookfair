using Cairo_book_fair.DBContext;
using Cairo_book_fair.Models;

namespace Cairo_book_fair.Repositories
{
    public class CartRepository : Repository<Cart>, ICartRepository
    {
        public CartRepository(Context _context) : base(_context)
        {
        }

        public Cart GetCartByUserId(string userId)
        {
            return Context.Set<Cart>().Where(c => c.UserId == userId).FirstOrDefault();
        }



    }
}

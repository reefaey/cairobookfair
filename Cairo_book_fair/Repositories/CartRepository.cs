using Cairo_book_fair.DBContext;
using Cairo_book_fair.Models;

namespace Cairo_book_fair.Repositories
{
    public class CartRepository : Repository<Cart>, ICartRepository
    {
        public CartRepository(Context _context) : base(_context)
        {
        }
    }
}

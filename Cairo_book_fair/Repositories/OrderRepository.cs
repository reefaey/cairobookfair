using Cairo_book_fair.DBContext;
using Cairo_book_fair.Models;

namespace Cairo_book_fair.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(Context _context) : base(_context)
        {
        }
    }
}

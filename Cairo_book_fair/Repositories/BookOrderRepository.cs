using Cairo_book_fair.DBContext;
using Cairo_book_fair.Models;

namespace Cairo_book_fair.Repositories
{
    public class BookOrderRepository : Repository<BookOrder>, IBookOrderRepository
    {
        public BookOrderRepository(Context _context) : base(_context)
        {
        }
    }
}

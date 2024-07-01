using Cairo_book_fair.DBContext;
using Cairo_book_fair.Models;

namespace Cairo_book_fair.Repositories
{
    public class BookCartRepository : Repository<BookCart>, IBookCartRepository
    {
        public BookCartRepository(Context _context) : base(_context)
        {
        }
    }
}

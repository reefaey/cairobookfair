using Cairo_book_fair.DBContext;
using Cairo_book_fair.Models;

namespace Cairo_book_fair.Repositories
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(Context _context) : base(_context)
        {

        }

    }
}

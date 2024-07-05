using Cairo_book_fair.DBContext;
using Cairo_book_fair.Models;

namespace Cairo_book_fair.Repositories
{
    public class BookCartRepository : Repository<BookCart>, IBookCartRepository
    {
        public BookCartRepository(Context _context) : base(_context)
        {
        }

        public BookCart GetBookCart(int cartId,  int bookId)
        {
            BookCart bookCart = Context.Set<BookCart>()
                .Where(c => c.CartId == cartId && c.BookId == bookId)
                .FirstOrDefault();

            return bookCart;
        }

        public bool IsBookAdded(int cartId, int bookId)
        {
            BookCart? bookCart = Context.Set<BookCart>()
                .Where(c => c.CartId == cartId && (c.BookId == bookId))
                .FirstOrDefault();

            return bookCart != null ? true : false;
        }

        public List<BookCart> GetAllBooksInCart(int cartId)
        {
            List<BookCart> itemsList = Context.BooksCarts
                .Where(c =>  cartId == c.CartId)
                .ToList();

            return itemsList;
        }

    }
}

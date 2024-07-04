using Cairo_book_fair.Models;

namespace Cairo_book_fair.Repositories
{
    public interface IBookCartRepository : IRepository<BookCart>
    {
        public BookCart GetBookCart(int cartId, int bookId);
        public List<BookCart> GetAllBooksInCart(int cartId);
        public bool IsBookAdded(int cartId, int bookId);

    }
}

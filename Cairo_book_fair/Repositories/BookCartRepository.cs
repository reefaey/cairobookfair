using Cairo_book_fair.DBContext;
using Cairo_book_fair.Models;
using Microsoft.EntityFrameworkCore;

namespace Cairo_book_fair.Repositories
{
    public class BookCartRepository : Repository<BookCart>, IBookCartRepository
    {
        public BookCartRepository(Context _context) : base(_context)
        {
        }

        public BookCart GetBookCart(int cartId, int bookId)
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

        public List<BookCart>? GetAllBooksInCart(int cartId)
        {
            List<BookCart>? itemsList = Context.BooksCarts
                .Where(c => cartId == c.CartId)
                .ToList();

            if (itemsList.Count == 0)
            {
                return null;
            }

            return itemsList;
        }

        public async Task RemoveAllCartItemsAsync(int cartId)
        {
            var cartItems = await Context.Set<BookCart>()
                .Where(c => c.CartId == cartId)
                .ToListAsync();

            if (cartItems.Any())
            {
                Context.BooksCarts.RemoveRange(cartItems);
                await Context.SaveChangesAsync();
            }
        }

        public void RemoveAllItems(int cartId)
        {
            var itemsList = Context.BooksCarts.Where(i => i.CartId == cartId).ToList();
            if (itemsList.Any())
            {
                Context.BooksCarts.RemoveRange(itemsList);
                Context.SaveChanges();
            }
        }

    }
}

using Cairo_book_fair.DTOs;
using Cairo_book_fair.Models;

namespace Cairo_book_fair.Services
{
    public interface IBookCartService
    {

        public BookCart GetBookCart(int cartId, int bookId);
        public void AddBook(int cartId, int bookId);
        public void AddDonatedBook(int cartId, int bookId);
        public void RemoveItem(int cartId, int bookId);

        public void ChangeQuantity(string userId, int bookId, int quantity);

        public WholeCartItemsWithTotalPriceDTO GetCartBooks(int cartId);

        public void Save();


    }
}

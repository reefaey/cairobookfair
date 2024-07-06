using Cairo_book_fair.DTOs;
using Cairo_book_fair.Models;

namespace Cairo_book_fair.Services
{
    public interface IBookCartService
    {
        public bool IsBookAdded(int cartId, int bookId);
        public void AddItem(Cart cart, Book book);
        public void RemoveItem(Cart cart, Book book);
        public void ChangeQuantity(Cart cart, int bookId, int quantity);
        public WholeCartItemsWithTotalPriceDTO? GetAllCartItems(int cartId);
        public Task RemoveAllCartItems(Cart cart);
        public void Save();

    }
}

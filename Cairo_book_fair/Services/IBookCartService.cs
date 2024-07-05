using Cairo_book_fair.DTOs;

namespace Cairo_book_fair.Services
{
    public interface IBookCartService
    {
        public void AddItem(int cartId, int bookId);

        public void RemoveItem(int cartId, int bookId);

        public void ChangeQuantity(int cartId, int bookId, int quantity);

        public WholeCartItemsWithTotalPriceDTO GetAllCartItems(int cartId);

        public void RemoveAllCartItems(int cartId);

        public void Save();

    }
}

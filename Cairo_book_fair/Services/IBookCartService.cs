using Cairo_book_fair.DTOs;

namespace Cairo_book_fair.Services
{
    public interface IBookCartService
    {
        public void AddItem(int cartId, int bookId);

        public void RemoveItem(int cartId, int bookId);

        public void ChangeQuantity(string userId, int bookId, int quantity);

        public List<CartItemDTO> GetAllCartItems(int cartId);

        public void Save();


    }
}

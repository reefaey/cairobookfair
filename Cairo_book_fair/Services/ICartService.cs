using Cairo_book_fair.Models;

namespace Cairo_book_fair.Services
{
    public interface ICartService : IService<Cart>
    {
        public void Insert(string userId);
        public void UpdateID(int cartId, string userId);
        public void Save();

    }
}

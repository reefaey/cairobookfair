using Cairo_book_fair.Models;

namespace Cairo_book_fair.Repositories
{
    public interface IOrderRepository
    {
        public List<Order> GetAll();
        public Order Get(int id);
        void Insert(Order item);
        void Update(Order item);
        void Delete(Order item);
        public void Save();
        public Cart GetCartByUserId(string userId);
        public User GetUserById(string userId);

    }
}

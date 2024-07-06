using Cairo_book_fair.DBContext;
using Cairo_book_fair.Models;
using Microsoft.EntityFrameworkCore;

namespace Cairo_book_fair.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly Context context;

        public OrderRepository(Context context)
        {
            this.context = context;
        }

        public void Delete(Order item)
        {
            context.Remove(item);
        }

        public Order Get(int id)
        {
            return context.Orders.Include(o => o.BookOrders).FirstOrDefault(o => o.Id == id);
        }

        public List<Order> GetAll()
        {
            return context.Orders.Include(o => o.BookOrders).ToList();
        }

        public void Insert(Order item)
        {
            context.Orders.Add(item);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(Order item)
        {
            context.Orders.Update(item);
        }
        public Cart GetCartByUserId(string userId)
        {
            Cart cart = context.Carts.Include(c => c.BookCarts).FirstOrDefault(c => c.UserId == userId);
            return cart;

        }

        public User GetUserById(string userId)
        {
            return context.Users.SingleOrDefault(u => u.Id == userId);
        }
    }
}

using Cairo_book_fair.Models;
using Cairo_book_fair.Repositories;

namespace Cairo_book_fair.Services
{
    public class OrderService : IOrderService

    {
        private readonly IOrderRepository orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }
        public void Delete(Order item)
        {
            orderRepository.Delete(item);
        }

        public Order Get(int id)
        {
            return orderRepository.Get(id);
        }

        public List<Order> Get(Func<Order, bool> where)
        {
            return orderRepository.Get(where);
        }

        public List<Order> GetAll(string include = null)
        {
            return orderRepository.GetAll(include);
        }

        public void Insert(Order item)
        {
            orderRepository.Insert(item);
        }

        public void Save()
        {
            orderRepository.Save();
        }

        public void Update(Order item)
        {
            orderRepository.Update(item);
        }
    }
}

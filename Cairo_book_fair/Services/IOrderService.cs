using Cairo_book_fair.DTOs;
using Cairo_book_fair.Models;

namespace Cairo_book_fair.Services
{
    public interface IOrderService
    {
        public OrderDto Get(int id);
        public List<OrderDto> GetAll();
        public void Insert();

        //void Update(OrderDto item);
        void Delete(int id);

    }
}

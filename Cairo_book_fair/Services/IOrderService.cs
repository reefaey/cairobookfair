using Cairo_book_fair.DTOs;

namespace Cairo_book_fair.Services
{
    public interface IOrderService
    {
        public OrderDto Get(int id);
        public List<OrderDto> GetAll();
        void Insert();
        void Update(OrderDto item);
        void Delete(int id);

    }
}

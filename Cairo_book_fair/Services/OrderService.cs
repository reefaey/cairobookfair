using AutoMapper;
using Cairo_book_fair.DTOs;
using Cairo_book_fair.Models;
using Cairo_book_fair.Repositories;
using System.Security.Claims;

namespace Cairo_book_fair.Services
{
    public class OrderService : IOrderService

    {
        private readonly IOrderRepository orderRepository;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IBookCartRepository bookCartRepository;

        public OrderService(IOrderRepository orderRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor, IBookCartRepository bookCartRepository)
        {
            this.orderRepository = orderRepository;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
            this.bookCartRepository = bookCartRepository;
        }

        private string GetCurrentUserId()
        {
           
            return httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
        private string GetCurrentUserName()
        {
            return httpContextAccessor.HttpContext.User.Identity.Name;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////
        public void Delete(int id)
        {
            Order order = orderRepository.Get(id);
            if (order != null)
            {
                orderRepository.Delete(order);
                orderRepository.Save();
            }
            else
            {
                throw new KeyNotFoundException();
            }

        }

        public OrderDto Get(int id)
        {
            Order order = orderRepository.Get(id);
            if (order != null)
            {
                OrderDto orderDto = mapper.Map<OrderDto>(order);
                return orderDto;
            }
            else
            {
                throw new KeyNotFoundException();
            }

        }

        public List<OrderDto> GetAll()
        {
            var Orders = orderRepository.GetAll();
            List<OrderDto> ordersDto = mapper.Map<List<OrderDto>>(Orders);
            return ordersDto;
        }

        public void Insert() 
        {
            Order order = new Order();      //mapper.Map<Order>(Orderdto);
            var userId = GetCurrentUserId();
             order.UserId = userId;
            var user = orderRepository.GetUserById(userId);
            // order.ShipmentId = user.ShipmentId;
            Cart cart = orderRepository.GetCartByUserId(userId);
            if (cart.BookCarts != null)
            {
                order.BookOrders = new List<BookOrder>();
                foreach (var bookcart in cart.BookCarts)
                {
                    var bookOrder = new BookOrder()
                    {

                        BookId = bookcart.BookId,
                        Quantity = bookcart.Quantity,
                        OrderId = order.Id,
                        //Order = order
                    };
                    order.BookOrders.Add(bookOrder);
                }

                order.TotalPrice = cart.TotalCost;

                ///Delete item from cart

            }
            else
            {
                throw new Exception("Cart has no book carts");
            } 
            orderRepository.Insert(order);
            orderRepository.Save();
            bookCartRepository.RemoveAllItems(cart.Id);
           // return order.Id;
        }


        //public void Update(OrderDto orderDto)
        //{
        //    Order orderDb = orderRepository.Get(orderDto.Id);
        //    if (orderDb == null)
        //    {
        //        throw new Exception("Order Not Found");
        //    }
        //    mapper.Map(orderDto, orderDb);

        //    foreach (var bookOrderDtos in orderDto.BookOrders)
        //    {
        //        var bookOrderDb = orderDb.BookOrders.FirstOrDefault(bo => bo.Id == bookOrderDtos.Id);
        //        if (bookOrderDb == null)
        //        {
        //            var newBookOrder = mapper.Map<BookOrder>(bookOrderDtos);
        //            orderDb.BookOrders.Add(newBookOrder);
        //        }
        //        else
        //        {
        //            bookOrderDb.BookId = bookOrderDtos.Id;
        //            bookOrderDb.Quantity = bookOrderDtos.Quantity;
        //        }
        //    }
        //    orderRepository.Update(orderDb);
        //    orderRepository.Save();

        //}









        //public void Insert(OrderDto item)
        //{
        //    Order order = mapper.Map<Order>(item);
        //    orderRepository.Insert(order);
        //    orderRepository.Save();
        //    List<BookOrder> bookOrders = new List<BookOrder>();
        //    foreach (var bookOrder in item.BookOrders)
        //    {
        //        Book book = bookRepository.Get(bookOrder.BookId);
        //        order.TotalPrice += book.Price;
        //        BookOrder bookOr = new BookOrder()
        //        { Quantity = bookOrder.Quantity, BookId = bookOrder.BookId, Order = order, OrderId = order.Id };
        //        bookOrders.Add(bookOr);

        //    }
        //    order.BookOrders = bookOrders;
        //    orderRepository.Save();
        //    bookOrderRepository.Save();
        //}

    }
}

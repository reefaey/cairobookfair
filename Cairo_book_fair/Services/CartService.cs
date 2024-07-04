using Cairo_book_fair.DTOs;
using Cairo_book_fair.Models;
using Cairo_book_fair.Repositories;
using Microsoft.AspNetCore.Identity;

namespace Cairo_book_fair.Services
{
    public class CartService : Service<Cart>, ICartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly IBookCartService _bookCartService;
        public CartService(ICartRepository cartRepository, IBookCartService bookCartService ,IRepository<Cart> repository) : base(repository)
        {
            _cartRepository = cartRepository;
            _bookCartService = bookCartService;
        }


        public Cart Get(int id)
        {
            return _cartRepository.Get(id);
        }

        //public List<CartItemDTO> GetAllCartItems()
        //{
        //    _cartRepository.get
        //}

        //public WholeCartItemsWithTotalPriceDTO GetAllCartItems()
        //{

        //    //used + new
        //}

        public Cart GetCartByUserId(string userId)
        {
            return _cartRepository.GetCartByUserId(userId);
        }


        public void UpdateID(int cartId, string userId)
        {
            
            Cart cart = _cartRepository.Get(cartId);
            cart.UserId = userId;
            _cartRepository.Update(cart);
        }

        public void Insert(string userId)
        {
            Cart item = new()
            {
                UserId = userId,
                TotalCost = 0
            };
            _cartRepository.Insert(item);
        }

        public void Update(Cart item)
        {
            _cartRepository.Update(item);
        }

        public void Save()
        {
            _cartRepository.Save();
        }

    }
}

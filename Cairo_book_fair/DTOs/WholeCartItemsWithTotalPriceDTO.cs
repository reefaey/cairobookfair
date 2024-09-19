namespace Cairo_book_fair.DTOs
{
    public class WholeCartItemsWithTotalPriceDTO
    {
        public List<CartItemDTO> cartItems { get; set; }
        public decimal totalPrice { get; set; }
    }
}

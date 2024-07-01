using Cairo_book_fair.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cairo_book_fair.DTOs
{
    public class CartItemDTO
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public int BookId { get; set; }
        public int Quantity { get; set; }

    }
}

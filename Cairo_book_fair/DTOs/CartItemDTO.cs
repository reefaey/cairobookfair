using Cairo_book_fair.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cairo_book_fair.DTOs
{
    public class CartItemDTO
    {
        public int BookId { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int Quantity { get; set; }
    }
}

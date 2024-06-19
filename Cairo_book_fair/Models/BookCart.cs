using System.ComponentModel.DataAnnotations.Schema;

namespace Cairo_book_fair.Models
{
    public class BookCart
    {
        public int Id { get; set; }
        [ForeignKey("Cart")]
        public int CartId { get; set; }
        [ForeignKey("Book")]
        public int BookId { get; set; }
        public int Quantity { get; set; } // Quantity of the specific book in the cart
        public Cart Cart { get; set; }
        public Book Book { get; set; }
    }
}

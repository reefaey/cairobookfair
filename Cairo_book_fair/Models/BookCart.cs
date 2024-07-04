using System.ComponentModel.DataAnnotations.Schema;

namespace Cairo_book_fair.Models
{
    public class BookCart
    {
        public int Id { get; set; }
        public int Quantity { get; set; } // Quantity of the specific book in the cart

        [ForeignKey("Cart")]
        public int CartId { get; set; }
        public Cart Cart { get; set; }

        [ForeignKey("Book")]
        public int BookId { get; set; }
        public Book Book { get; set; }

        [ForeignKey("UsedBook")]
        public int DonatedBookId { get; set; }
        public UsedBook? UsedBook { get; set; }
    }
}

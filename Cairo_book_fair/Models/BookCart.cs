using System.ComponentModel.DataAnnotations.Schema;

namespace Cairo_book_fair.Models
{
    public class BookCart
    {
        public int Id { get; set; }

        [ForeignKey("Book")]
        public int BookID { get; set; }

        [ForeignKey("Cart")]
        public int CartID { get; set; }

    }
}

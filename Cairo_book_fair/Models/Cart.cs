using System.ComponentModel.DataAnnotations.Schema;

namespace Cairo_book_fair.Models
{
    public class Cart
    {
        public int Id { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }

        [Column(TypeName = "decimal(18, 2)")] //Alternate for OnModelCreate as we do in book and Order
        public decimal TotalCost { get; set; } = 0;
        public List<BookCart>? BookCarts { get; set; }
        public User User { get; set; }

    }
}

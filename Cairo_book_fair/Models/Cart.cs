using System.ComponentModel.DataAnnotations.Schema;

namespace Cairo_book_fair.Models
{
    public class Cart
    {
        public int Id { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        public decimal TotalCost { get; set; }
        public List<BookCart>? BookCarts { get; set; }
        public User User { get; set; }

    }
}

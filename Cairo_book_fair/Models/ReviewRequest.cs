using System.ComponentModel.DataAnnotations.Schema;

namespace Cairo_book_fair.Models
{
    public class ReviewRequest
    {
        public int Id { get; set; }

        public 

        [ForeignKey("Review")]
        public int ReviewId { get; set; }
        public Review Review { get; set; }

        [ForeignKey("User")]

        public string UserId { get; set; }
        public User User { get; set; }
    }
}

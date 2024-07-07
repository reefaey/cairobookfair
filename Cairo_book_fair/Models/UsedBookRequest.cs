using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Cairo_book_fair.Enums;

namespace Cairo_book_fair.Models
{
    public class UsedBookRequest
    {
        public int Id { get; set; }
        public string BookName { get; set; }
        public string ImageURL { get; set; }
        public string Description { get; set; }
        public Condition BookCondition { get; set; } = Condition.Used; // Description of the book's condition
        public RequestStatus RequestStatus { get; set; } = RequestStatus.Pending; // Pending, Approved, Declined
        public DateTime RequestDate { get; set; } = DateTime.Now;
        public DateTime? ReviewedAt { get; set; } // Time of approval/rejection

        [ForeignKey("UsedBook")]
        public int? UsedBookId { get; set; }
        public UsedBook? UsedBook { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }
    }
}

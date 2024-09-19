using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Cairo_book_fair.Enums;

namespace Cairo_book_fair.Models
{
    public class UsedBookRequest
    {
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        [Required]
        public string BookTitle { get; set; }

        public string BookDescription { get; set; }

        public Condition BookCondition { get; set; } = Condition.Used; // Description of the book's condition

        public RequestStatus RequestStatus { get; set; } = RequestStatus.Pending; // Pending, Approved, Declined

        public DateTime RequestDate { get; set; } = DateTime.Now;
        public int? UsedBookId { get; set; }
        [ForeignKey("UsedBookId")]
        public UsedBook UsedBook { get; set; }

    }
}

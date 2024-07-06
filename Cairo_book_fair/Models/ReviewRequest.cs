using Cairo_book_fair.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cairo_book_fair.Models
{
    public class ReviewRequest
    {
        public int Id { get; set; }
        public string Comment { get; set; } // Comment from the user
        public RequestStatus RequestStatus { get; set; } = RequestStatus.Pending;
        public DateTime RequestedAt { get; set; } = DateTime.Now;
        public DateTime? ReviewedAt { get; set; } // Time of approval/rejection
        public string? AdminComments { get; set; } // Comments from admin on rejection/approval

        [ForeignKey("Review")]
        public int? ReviewId { get; set; } // Nullable because the review might not be created yet
        //Nullable Foreign Key (ReviewId): This means that when a ReviewRequest is created, the corresponding Review might not exist yet. The ReviewRequest is created first and then, upon approval, the Review is created and linked.
        public Review? Review { get; set; }
        // Nullable Navigation Property (Review): This makes sense because initially, when the request is created, there is no Review object yet. The Review will be created only after the request is approved.

        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }

        [ForeignKey("Book")]
        public int BookId { get; set; }
        public Book Book { get; set; }


        //[ForeignKey("Review")]
        //public int ReviewId { get; set; }
        //public Review Review { get; set; }
    }
}

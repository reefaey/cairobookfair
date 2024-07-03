using System.ComponentModel.DataAnnotations.Schema;

namespace Cairo_book_fair.Models
{
    public class Donation
    {
        public int Id { get; set; }
        //public List<UsedBook> UsedBooks { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public DateTime DonationDate { get; set; }
        public string Condition { get; set; } // Condition of the donated book (e.g., "New", "Good", "Fair", "Poor")
        //public Condition Condition { get; set; } Enum
        public string? Notes { get; set; }
        public User User { get; set; }
    }
}

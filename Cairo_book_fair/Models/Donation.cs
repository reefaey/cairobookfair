using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;
using Cairo_book_fair.Enums;

namespace Cairo_book_fair.Models
{
    public class Donation
    {
        public int Id { get; set; }
        public User Account {  get; set; }
        public List<Book> Books {  get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }

        [ForeignKey("Book")]
        public int BookId { get; set; }
        public DateTime DonationDate { get; set; }
        public string Condition { get; set; } // Condition of the donated book (e.g., "New", "Good", "Fair", "Poor")
        //public Condition Condition { get; set; } Enum
        public string? Notes { get; set; }
        public User User { get; set; }
        public Book Book { get; set; }
    }
}

using System.ComponentModel.DataAnnotations.Schema;

namespace Cairo_book_fair.Models
{
    public class UsedBook
    {
        public int Id { get; set; }
        public string DonorName { get; set; }
        public string BookName { get; set; }
        public string ImageURL { get; set; }
        public string AuthorName { get; set; }

        [ForeignKey("User")]
        public string? UserId { get; set; }
        public User? User { get; set; }

        //[ForeignKey("Donation")]
        //public int DonationID { get; set; }
        //public Donation Donation { get; set; }



    }
}

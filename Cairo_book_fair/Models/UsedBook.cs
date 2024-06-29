using System.ComponentModel.DataAnnotations.Schema;

namespace Cairo_book_fair.Models
{
    public class UsedBook
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AuthorName { get; set; }
        public string ImageURL { get; set; }
        public string Category { get; set; }
        public DateTime DateOfPurchase { get; set; }

        [ForeignKey("Donation")]
        public int DonationID { get; set; }
        public Donation Donation { get; set; }



    }
}

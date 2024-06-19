namespace Cairo_book_fair.Models
{
    public class Donation
    {
        public int Id { get; set; }
        public User Account { get; set; }
        public List<UsedBook> Books { get; set; }
    }
}

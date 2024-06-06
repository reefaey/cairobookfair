namespace Cairo_book_fair.Models
{
    public class Review
    {
        public int Id { get; set; }
        public DateTime Date {  get; set; }
        public string Comment { get; set; }
        public Book Book { get; set; }
        public Account Account { get; set; }
    }
}

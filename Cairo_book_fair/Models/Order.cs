namespace Cairo_book_fair.Models
{
    public class Order
    {
        public int Id { get; set; }
        public decimal TotalPrice { get; set; }
        public List<Book> Items { get; set; }
        public User Account { get; set; }
    }
}

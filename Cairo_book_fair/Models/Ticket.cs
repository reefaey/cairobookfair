namespace Cairo_book_fair.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public DateTime DateTime { get; set; }
        public User User { get; set; }
    }
}

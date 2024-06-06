namespace Cairo_book_fair.Models
{
    public class Account
    {
        public List<Ticket> Tickets { get; set; }
        public List<Review> Reviews { get; set; }
        public Cart Cart { get; set; }
        public List<Order>? Orders { get; set; }
    }
}

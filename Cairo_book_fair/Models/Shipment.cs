namespace Cairo_book_fair.Models
{
    public class Shipment
    {
        public int Id { get; set; }

        public string Address { get; set; }
        public DateTime Date { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}

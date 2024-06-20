using System.ComponentModel.DataAnnotations.Schema;

namespace Cairo_book_fair.Models
{
    public class Shipment
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public DateTime Date { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public string Status { get; set; } // E.g., Pending, Shipped, Delivered
        public string TrackingNumber { get; set; }

        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }

    }
}

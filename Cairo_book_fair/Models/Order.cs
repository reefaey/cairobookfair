using System.ComponentModel.DataAnnotations.Schema;

namespace Cairo_book_fair.Models
{
    public class Order
    {
        public int Id { get; set; }
        public decimal TotalPrice { get; set; }
        public List<BookOrder> BookOrders { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now; // Date the order was placed
      
        [ForeignKey("Shipment")]
        public int? ShipmentId { get; set; }
        public Shipment? Shipment { get; set; }
    }
}

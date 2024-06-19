using System.ComponentModel.DataAnnotations.Schema;

namespace Cairo_book_fair.Models
{
    public class Order
    {
        public int Id { get; set; }
        public float TotalPrice { get; set; }
        public List<Book> Items { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public User Account { get; set; }

        [ForeignKey("Shipment")]
        public int? ShipmentId { get; set; }
        public Shipment? Shipment { get; set; }
    }
}

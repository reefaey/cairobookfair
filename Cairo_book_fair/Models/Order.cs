using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cairo_book_fair.Models
{
    public class Order
    {
        public int Id { get; set; }
        public decimal TotalPrice { get; set; }


        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]  // specifies that the formatting should also be applied when the value is displayed in a text box for editing
        public DateTime OrderDate { get; set; } = DateTime.Now; // Date the order was placed

        public List<BookOrder> BookOrders { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public User? User { get; set; }

        //[ForeignKey("Shipment")]
        //public int? ShipmentId { get; set; }
        public Shipment? Shipment { get; set; }
    }
}

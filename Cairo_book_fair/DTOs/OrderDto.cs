using System.ComponentModel.DataAnnotations;

namespace Cairo_book_fair.DTOs
{
    public class OrderDto
    {
        public int Id { get; set; }
        public decimal TotalPrice { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]  // specifies that the formatting should also be applied when the value is displayed in a text box for editing
        public DateTime OrderDate { get; set; } = DateTime.Now; // Date the order was placed
        public int? ShipmentId { get; set; }


        public List<BookOrderDto>? BookOrders { get; set; }

        // public string UserId { get; set; }

    }
}

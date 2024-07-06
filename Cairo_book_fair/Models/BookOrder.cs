using System.ComponentModel.DataAnnotations.Schema;

namespace Cairo_book_fair.Models
{
    //[Keyless]
    public class BookOrder
    {
        public int Id { get; set; } // if there is more properties than essential of join table as quantity then u require id?
        public int Quantity { get; set; }



        [ForeignKey("Book")]
        public int BookId { get; set; }
        public Book Book { get; set; }



        [ForeignKey("Order")]
        public int? OrderId { get; set; }
        public Order? Order { get; set; }
    }
}

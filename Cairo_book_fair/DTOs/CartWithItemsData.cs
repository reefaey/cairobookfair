using Cairo_book_fair.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cairo_book_fair.DTOs
{
    public class CartWithItemsData
    {
        public string UserId { get; set; }
        public List<int>? BooksId { get; set; }

        [Column(TypeName = "decimal(18, 2)")] //Alternate for OnModelCreate as we do in book and Order
        public decimal TotalCost { get; set; }
    }
}

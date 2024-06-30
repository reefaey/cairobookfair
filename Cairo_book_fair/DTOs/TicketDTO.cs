using Cairo_book_fair.Models;
using System.ComponentModel.DataAnnotations;

namespace Cairo_book_fair.DTOs
{
    public class TicketDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Phone { get; set; }

        [Range(1, 10)]
        public int Quantity { get; set; }
        public DateTime DateTime { get; set; } = DateTime.Now;
    }
}

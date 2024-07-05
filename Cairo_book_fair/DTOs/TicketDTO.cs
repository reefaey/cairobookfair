using Cairo_book_fair.Models;

namespace Cairo_book_fair.DTOs
{
    public class TicketDTO
    {
        public int Id { get; set; }
        public string TicketName { get; set; }
        public int Phone { get; set; }
        public int TicketNumber { get; set; }
        public float TicketPrice { get; set; }
        public DateTime DateTime { get; set; }
        public User User { get; set; }
    }
}

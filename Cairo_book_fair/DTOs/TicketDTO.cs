using Cairo_book_fair.Models;

namespace Cairo_book_fair.DTOs
{
    public class TicketDTO
    {
        public int Id { get; set; }
        public string userName { get; set; }
        public string Phone { get; set; }
        public decimal TicketPrice { get; set; } = 5;
        public int NoofTicket { get; set; } = 1;
        public DateTime DateTime { get; set; }
    }
}

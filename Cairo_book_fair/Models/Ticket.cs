using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cairo_book_fair.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [MaxLength(11)]
        public string Phone { get; set; }
        public decimal Price { get; set; } = 5;
        public int NoofTicket { get; set; } = 1;
        public DateTime DateTime { get; set; } = DateTime.Now;

        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }
    }
}

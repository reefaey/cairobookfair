using System.ComponentModel.DataAnnotations.Schema;

namespace Cairo_book_fair.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int phone { get; set; }
        public decimal Price { get; set; }
        public string Nid { get; set; }

        public DateTime DateTime { get; set; } = DateTime.Now;

        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }
    }
}

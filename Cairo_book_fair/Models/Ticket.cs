using System.ComponentModel.DataAnnotations.Schema;

namespace Cairo_book_fair.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Phone { get; set; }

        public float Price { get; set; }
        public string side { get; set; }

        public DateTime DateTime { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }
        public string side { get; set; }
    }
}

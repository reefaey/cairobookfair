using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cairo_book_fair.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Phone { get; set; }
        public decimal Price { get; set; }
        [MaxLength(14)]
        public string NID { get; set; } = "29988172672664";
        public DateTime DateTime { get; set; } = DateTime.Now;

        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }
    }
}

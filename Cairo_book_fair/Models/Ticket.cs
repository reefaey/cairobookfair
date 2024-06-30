using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace Cairo_book_fair.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int phone { get; set; }
        [DataType("decimal(18, 2)")]
        public decimal Price { get; set; }
        public DateTime DateTime { get; set; }

        [ForeignKey("User")]
        public string? UserId { get; set; }
        public User User { get; set; }
    }
}

using System.ComponentModel.DataAnnotations.Schema;

namespace Cairo_book_fair.Models
{
    public class Block
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Publisher Publisher{ get; set; }

        [ForeignKey("Hall")]
        public int HallId { get; set; }
        public Hall Hall { get; set; }
    }
}

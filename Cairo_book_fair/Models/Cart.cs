using System.ComponentModel.DataAnnotations.Schema;

namespace Cairo_book_fair.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public BookCart BookCart { get; set; }

        [ForeignKey("User")]
        public string userid { get; set; }

        public User Account { get; set; }

        public List<Book>? Books { get; set; }

    }
}

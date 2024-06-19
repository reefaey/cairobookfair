using System.ComponentModel.DataAnnotations.Schema;

namespace Cairo_book_fair.Models
{
    public class BookCategory
    {
        public int Id { get; set; }

        [ForeignKey("Book")]
        public int BookID { get; set; }

        [ForeignKey("Category")]
        public int CategoryID { get; set; }

        //public Book
    }
}

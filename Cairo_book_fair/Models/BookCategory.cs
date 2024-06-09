namespace Cairo_book_fair.Models
{
    public class BookCategory
    {
        public int Id { get; set; }
        public int BookFK { get; set; }
        public int CategoryFK { get; set; }

        //public Book
    }
}

namespace Cairo_book_fair.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BooksNumber { get; set; } = 0;
        public List<BookCategory>? BookCategories { get; set; }
    }
}

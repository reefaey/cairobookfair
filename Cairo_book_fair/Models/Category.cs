namespace Cairo_book_fair.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BooksNumber {  get; set; }
        public List<Book>? Books { get; set;}
    }
}

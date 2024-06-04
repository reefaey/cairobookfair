namespace Cairo_book_fair.Models
{
    public class Stage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Book> Books { get; set; }
        public List<Publisher>? Publishers{ get; set; }
    }
}

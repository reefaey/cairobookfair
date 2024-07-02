using Cairo_book_fair.Models;

namespace Cairo_book_fair.DTOs
{
    public class AuthorDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Image { get; set; }
        public string? Description { get; set; }
        public int NumberOfBooks { get; set; } = 0;
        public List<BookDto> Books { get; set; }
    }
}

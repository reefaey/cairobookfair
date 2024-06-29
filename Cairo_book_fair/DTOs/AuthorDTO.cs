using Cairo_book_fair.Models;

namespace Cairo_book_fair.DTOs
{
    public class AuthorDTO
    {
        public int id { get; }
        public string Name { get; set; }
        public string? Image { get; set; }
        public string? Description { get; set; }
        public int NumberOfBooks { get; set; } = 0;
    }
}

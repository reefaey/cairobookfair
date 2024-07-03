namespace Cairo_book_fair.DTOs
{
    public class BookDTO
    {
        public string Name { get; set; }
        public string? ImageUrl { get; set; }
        public decimal Price { get; set; }
        public string? PublishingYear { get; set; }
        public int? PagesNumber { get; set; }
        public int PublisherId { get; set; }
        public string? SoundBook { get; set; }
        public int AuthorId { get; set; }
        public List<int>? CategoryIds { get; set; }
    }
}

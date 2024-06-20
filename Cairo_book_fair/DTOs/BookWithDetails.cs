namespace Cairo_book_fair.DTOs
{
    public class BookWithDetails
    {
        public string BookName { get; set; }
        public string AuthorName { get; set; }
        public int HallNumber { get; set; }
        public string BlockName { get; set; }
        public string ImageUrl { get; set; }
        public string PublishingYear { get; set; }
        public int PagesNumber { get; set; }
        public List<string> CategoryNames { get; set; }
        public string? SoundBook { get; set; }

    }
}

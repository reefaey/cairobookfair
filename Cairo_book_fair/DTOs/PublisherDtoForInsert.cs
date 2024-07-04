namespace Cairo_book_fair.DTOs
{
    public class PublisherDtoForInsert
    {
        public string Name { get; set; }
        public int NumberOfBooks { get; set; }
        public string? ImageUrl { get; set; }
        public int BlockId { get; set; }
    }
}

namespace Cairo_book_fair.DTOs
{
    public class UsedBookDtoInsert
    {
        public string BookName { get; set; }

        //[NotMapped]
        //public IFormFile ImageFile { get; set; }
        public string? ImageUrl { get; set; }
        public string AuthorName { get; set; }
        public string Description { get; set; }
    }
}

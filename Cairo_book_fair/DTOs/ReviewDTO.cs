namespace Cairo_book_fair.DTOs
{
    public class ReviewDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }
        public int BookId { get; set; }
        public string UserId { get; set; }
    }
}

namespace Cairo_book_fair.DTOs
{
    public class BookOrderDto
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int BookId { get; set; }
        public int? OrderId { get; set; }
    }
}

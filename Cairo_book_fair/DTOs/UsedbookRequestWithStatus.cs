namespace Cairo_book_fair.DTOs
{
    public class UsedbookRequestWithStatus
    {
        public int Id { get; set; }
        public string BookName { get; set; }
        public string ImageURL { get; set; }
        public string Description { get; set; }
        public string RequestStatus { get; set; }
    }
}

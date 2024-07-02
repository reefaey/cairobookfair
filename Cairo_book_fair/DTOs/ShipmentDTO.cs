namespace Cairo_book_fair.DTOs
{
    public class ShipmentDTO
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public DateTime Date { get; set; }
        public int OrderId { get; set; }
        public string Status { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string UserId { get; set; }
    }
}

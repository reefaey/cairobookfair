using System.ComponentModel.DataAnnotations.Schema;

namespace Cairo_book_fair.Models
{
    public class Shipment
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }


        [ForeignKey("User")]
        public string UserId { get; set; }
        public User Account { get; set; }
    }
}

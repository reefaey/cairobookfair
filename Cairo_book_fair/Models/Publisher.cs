using System.ComponentModel.DataAnnotations.Schema;

namespace Cairo_book_fair.Models
{
    //public struct Location
    //{
    //    public string Hall;
    //    public string Stage;
    //}
    public class Publisher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfBooks { get; set; }

        [ForeignKey("Block")]
        public int BlockID { get; set; }
        public Block Block { get; set; }

        //public Location Location { get; set; }
        public List<Book> Books { get; set; }
    }
}

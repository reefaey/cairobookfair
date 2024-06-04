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
        //public Location Location { get; set; }
        public List<Book>? Books { get; set; }
    }
}

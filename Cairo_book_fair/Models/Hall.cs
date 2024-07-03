namespace Cairo_book_fair.Models
{
    public class Hall
    {
        public int Id { get; set; }
        public int HallNumber { get; set; }
        public List<Block> Blocks { get; set; }
    }
}
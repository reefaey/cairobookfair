namespace Cairo_book_fair.Models
{
    public class Hall
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Stage> Stages { get; set; }
    }
}

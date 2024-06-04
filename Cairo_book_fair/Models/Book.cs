using System.ComponentModel.DataAnnotations.Schema;

namespace Cairo_book_fair.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }

        [ForeignKey("Hall")]
        public int HallNumber { get; set; }
        public Hall Hall { get; set; }
        [ForeignKey("Stage")]
        public string StageName { get; set; }
        public Stage Stage { get; set; }
        public string ImageUrl { get; set; }
        public string PublishingYear { get; set; }
        public int PagesNumber { get; set; }
        public List<string> Category { get; set; }
        public string SoundBook { get; set; }
    }
}

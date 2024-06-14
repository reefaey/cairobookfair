using System.ComponentModel.DataAnnotations.Schema;

namespace Cairo_book_fair.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? ImageUrl { get; set; }
        public string? PublishingYear { get; set; }
        public int? PagesNumber { get; set; }
        public List<string> Category { get; set; }
        public Publisher Publisher { get; set; }
        public string? SoundBook { get; set; }
        public Author Author {  get; set; }
        public List<Review>? Reviews { get; set; }
    }
}

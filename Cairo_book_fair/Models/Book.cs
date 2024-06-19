using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cairo_book_fair.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? ImageUrl { get; set; }
        public decimal Price { get; set; }
        public string? PublishingYear { get; set; }
        public int? PagesNumber { get; set; }

        [ForeignKey("Category")]
        public int? CategoryID { get; set; }

        //public List<int>? CategoriesID { get; set; }
        public List<Category>? Categories { get; set; }

        [ForeignKey("Publisher")]
        public int PublisherID { get; set; }
        public Publisher Publisher { get; set; }
        public string? SoundBook { get; set; }

        [ForeignKey("Author")]
        public int? AuthorID { get; set; }
        public Author Author {  get; set; }

        [ForeignKey("Review")]
        public int? ReviewID { get; set; }
        public List<Review>? Reviews { get; set; }

        [ForeignKey("Cart")]
        public int? CartId { get; set; }
        public Cart? Cart { get; set; }
    }
}

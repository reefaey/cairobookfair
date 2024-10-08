﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Cairo_book_fair.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? DonorName { get; set; }
        public string Description { get; set; }

        //[NotMapped]
        //public IFormFile ImageFile { get; set; }
        public string? ImageUrl { get; set; }
        public decimal Price { get; set; } = 0;
        public string? PublishingYear { get; set; }
        public int? PagesNumber { get; set; }

        //[ForeignKey("Category")]
        //public int? CategoryID { get; set; }

        //public List<int>? CategoriesID { get; set; }
        public List<BookCategory>? BookCategories { get; set; }

        [ForeignKey("Publisher")]
        public int? PublisherId { get; set; }
        public Publisher Publisher { get; set; }
        public string? SoundBook { get; set; }

        [ForeignKey("Author")]
        public int? AuthorId { get; set; }
        public Author Author { get; set; }
        public bool IsAvailableForDonation { get; set; } = false;
        public List<Review>? Reviews { get; set; }

        //[ForeignKey("Donation")]
        //public int? DonationId { get; set; }
        //public Donation? Donation { get; set; }
        public List<BookCart>? BookCarts { get; set; }
        public List<BookOrder>? BookOrders { get; set; }


        [ForeignKey("User")]
        public string? UserId { get; set; }
        public User? User { get; set; }

        //There is no FK For One to Many And Many To Many Relationships
    }
}

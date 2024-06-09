﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Cairo_book_fair.Models
{
    public class User : IdentityUser
    {
        [Required]
        [MaxLength(25, ErrorMessage = "Name Must Be Less Than 25 Char")]
        [MinLength(3, ErrorMessage = "Name Must Be More That 3 Char")]
        public string Name { get; set; } = "sa";

        public string? ProfileImage { get; set; } = "default";

        [MaxLength(150, ErrorMessage = "Bio Must Be Less Than 150 Char")]
        public string? Bio { get; set; } = "Hello";

        public string? Location { get; set; } = "";
        public DateTime JoinDate { get; set; } = DateTime.Now;

        public List<Book>? UsedBooks { get; set; }
        public List<Ticket>? Tickets { get; set; }
        public List<Review>? Reviews { get; set; }
        public Cart Cart { get; set; }
        public List<Order>? Orders { get; set; }
        public List<Author>? AuthorsFollowing { get; set; }
    }
}
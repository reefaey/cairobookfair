using System.ComponentModel.DataAnnotations;

namespace Cairo_book_fair.DTOs
{
    public class UserResgisterDTO
    {
        [Required]

        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        [Required]
        public string Fullname { get; set; }
        [Required]
        public string Email { get; set; }
        public string? Location { get; set; }
        public string? ProfileImage { get; set; }
        public string? Bio { get; set; } = " ";
    }
}


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cairo_book_fair.Models;
public class Transportation
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<string> routes { get; set; } = new();
    //public DateOnly  Year { get; set; }
}
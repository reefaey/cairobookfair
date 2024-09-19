using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cairo_book_fair.Models;
public class Visitors
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public int PublishingHouse { get; set; }

    public int Hall { get; set; }

    public int Cycle { get; set; }

    public int VisitorsCount { get; set; }

    public DateTime Date { get; set; }



}
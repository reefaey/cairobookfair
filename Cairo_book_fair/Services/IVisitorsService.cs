using Cairo_book_fair.DTOs;
using Cairo_book_fair.Models;

namespace Cairo_book_fair.Services.Interfaces;
public interface IVisitorsService
{
    List<Visitors> GetAll();
    VisitorsDTO Update(int id, VisitorsDTO visitorsDTO);

    VisitorsDTO Add(VisitorsDTO visitorsDTO);

    public statistics GetStatistics();
}
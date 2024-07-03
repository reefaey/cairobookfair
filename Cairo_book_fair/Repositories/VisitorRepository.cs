using Cairo_book_fair.DBContext;
using Cairo_book_fair.Models;

namespace Cairo_book_fair.Repositories;
public class VisitorRepository : IVisitorRepository
{
    private readonly Context _context;

    public VisitorRepository(Context context)
    {
        _context = context;
    }

    public List<Visitors> GetAll()
    {
        return _context.Visitors.ToList();
    }

    public Visitors Update(int id, Visitors visitor)
    {
        var existingVisitor = _context.Visitors.Find(id);
        try
        {
            if (existingVisitor != null)
            {
                existingVisitor.PublishingHouse = visitor.PublishingHouse;
                existingVisitor.Hall = visitor.Hall;
                existingVisitor.Cycle = visitor.Cycle;
                existingVisitor.Date = visitor.Date;
                _context.SaveChanges();
            }
            return existingVisitor;

        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public Visitors Add(Visitors visitor)
    {
        _context.Visitors.Add(visitor);
        _context.SaveChanges();
        return visitor;
    }
}

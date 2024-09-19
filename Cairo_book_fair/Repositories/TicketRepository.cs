using Cairo_book_fair.DBContext;
using Cairo_book_fair.Models;
using Cairo_book_fair.Repositories;

public class TicketRepository : Repository<Ticket>, ITicketRepository
{
    public TicketRepository(Context _context) : base(_context)
    {
    }

    public Ticket GetTicketByUserId(string userId)
    {
        return Context.Set<Ticket>().Where(c => c.UserId == userId).FirstOrDefault();
    }
}
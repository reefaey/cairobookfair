using Cairo_book_fair.Models;

namespace Cairo_book_fair.Repositories
{
    public interface ITicketRepository : IRepository<Ticket>
    {
        public Ticket GetTicketByUserId(string userId);
    }
}

using Cairo_book_fair.Models;
using Cairo_book_fair.Repositories;

namespace Cairo_book_fair.Services
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository ticketRepository;

        public TicketService(ITicketRepository ticketRepository)
        {
            this.ticketRepository = ticketRepository;
        }

        public void Delete(Ticket item)
        {
            ticketRepository.Delete(item);
        }

        public Ticket Get(int id)
        {
            return ticketRepository.Get(id);
        }

        public List<Ticket> Get(Func<Ticket, bool> where)
        {
            return ticketRepository.Get(where);
        }

        public List<Ticket> GetAll(string include = null)
        {
            return ticketRepository.GetAll(include);
        }

        public void Insert(Ticket item)
        {
            ticketRepository.Insert(item);
        }

        public void Save()
        {
            ticketRepository.Save();
        }

        public void Update(Ticket item)
        {
            ticketRepository.Update(item);
        }
    }
}

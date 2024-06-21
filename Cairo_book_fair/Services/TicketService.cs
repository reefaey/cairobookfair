using Cairo_book_fair.DBContext;
using Cairo_book_fair.DTOs;
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

        public List<TicketDTO> GetAllDTO(string include = null)
        {
            var tickets = ticketRepository.GetAll(include)
                .Select(ticket => new TicketDTO
                {
                    Id = ticket.Id,
                    Name = ticket.Name,
                    Phone = ticket.Phone,
                    Price = ticket.Price,
                    DateTime = ticket.DateTime,
                    User = ticket.User
                })
                .ToList();

            return tickets;
        }

        public List<Ticket> GetAll(string include = null)
        {
            return ticketRepository.GetAll(include);
        }

        public Ticket Get(int id)
        {
            return ticketRepository.Get(id);
        }

        public List<Ticket> Get(Func<Ticket, bool> where)
        {
            return ticketRepository.Get(where);
        }

        public void Insert(Ticket item)
        {
            ticketRepository.Insert(item);
        }

        public void Update(Ticket item)
        {
            ticketRepository.Update(item);
        }

        public void Save()
        {
            ticketRepository.Save();
        }
    }
}

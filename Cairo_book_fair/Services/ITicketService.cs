using Cairo_book_fair.DTOs;
using Cairo_book_fair.Models;
using Cairo_book_fair.Repositories;

namespace Cairo_book_fair.Services
{
    public interface ITicketService : IService<Ticket>
    {
        public TicketDTO? GetDTO(string userId);
        public Ticket? Get(string userId);
        public void InsertTicket(NewTicketDTO newTicketDTO, string userName, string userId);
        public void UpdateTicket(Ticket ticket, NewTicketDTO newTicket);
    }
}

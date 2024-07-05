using Cairo_book_fair.DTOs;
//using Cairo_book_fair.Migrations;
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

        public Ticket? Get(string userId)
        {
            Ticket? ticket = ticketRepository.GetTicketByUserId(userId);
            if (ticket != null)
            {
                return ticket;
            }
            return null;
        }

        public TicketDTO? GetDTO(string userId)
        {
            Ticket ticket = ticketRepository.GetTicketByUserId(userId);
            if (ticket !=  null)
            {
                TicketDTO ticketDTO = new();
                ticketDTO.Id = ticket.Id;
                ticketDTO.userName = ticket.Name;
                ticketDTO.Phone = ticket.Phone;
                ticketDTO.NoofTicket = ticket.NoofTicket;
                ticketDTO.DateTime = ticket.DateTime;
                if (ticket.NoofTicket != 0)
                {
                    ticketDTO.TicketPrice = ticket.Price * ticket.NoofTicket;
                }
                return ticketDTO;
            }
            return null;
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

        public void UpdateTicket(Ticket ticket, NewTicketDTO newTicket)
        {
            ticket.Phone = newTicket.Phone;
            ticket.NoofTicket = newTicket.NumberOfTicket;
            ticket.DateTime = DateTime.Now;
            
            ticketRepository.Update(ticket);
        }

        public void InsertTicket(NewTicketDTO newTicketDTO, string userName, string userId)
        {
            Ticket item = new Ticket();

            item.Name = userName;
            item.Phone = newTicketDTO.Phone;
            item.NoofTicket = newTicketDTO.NumberOfTicket;
            item.DateTime = DateTime.Now;
            item.UserId = userId;
            item.Price = 5;

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

        public Ticket Get(int id)
        {
            return ticketRepository.Get(id);
        }
    }
}

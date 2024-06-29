using Cairo_book_fair.DTOs;
using Cairo_book_fair.Models;
using Cairo_book_fair.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Cairo_book_fair.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService ticketService;

        public TicketController(ITicketService ticketService)
        {
            this.ticketService = ticketService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TicketDTO>> GetAllTickets()
        {
            var tickets = ticketService.GetAll();
            var ticketDTOs = new List<TicketDTO>();

            foreach (var ticket in tickets)
            {
                ticketDTOs.Add(new TicketDTO
                {
                    Id = ticket.Id,
                    TicketName = ticket.Name,
                    Phone=ticket.phone,
                    TicketNumber = ticket.TicketNum,
                    TicketPrice = ticket.Price,
                    DateTime = ticket.DateTime,
                    User = ticket.User
                });
            }

            return Ok(ticketDTOs);
        }

        [HttpGet("{id}")]
        public ActionResult<TicketDTO> GetTicket(int id)
        {
            var ticket = ticketService.Get(id);

            if (ticket == null)
            {
                return NotFound();
            }

            var ticketDTO = new TicketDTO
            {
                Id = ticket.Id,
                TicketName = ticket.Name,
                TicketNumber = ticket.TicketNum,
                Phone = ticket.phone,
                TicketPrice = ticket.Price,
                DateTime = ticket.DateTime,
                User = ticket.User
            };

            return Ok(ticketDTO);
        }

        [HttpPost]
        public ActionResult<TicketDTO> CreateTicket(TicketDTO ticketDTO)
        {
            var ticket = new Ticket
            {
                Name = ticketDTO.TicketName,
                TicketNum = ticketDTO.TicketNumber,
                phone = ticketDTO.Phone,
                Price = ticketDTO.TicketPrice,
                DateTime = ticketDTO.DateTime,
                UserId = ticketDTO.User.Id
            };

            ticketService.Insert(ticket);
            ticketService.Save();

            ticketDTO.Id = ticket.Id;

            return CreatedAtAction(nameof(GetTicket), new { id = ticketDTO.Id }, ticketDTO);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateTicket(int id, TicketDTO ticketDTO)
        {
            if (id != ticketDTO.Id)
            {
                return BadRequest();
            }

            var ticket = ticketService.Get(id);
            if (ticket == null)
            {
                return NotFound();
            }

            ticket.Name = ticketDTO.TicketName;
            ticket.TicketNum = ticketDTO.TicketNumber;
            ticket.phone = ticketDTO.Phone;
            ticket.Price = ticketDTO.TicketPrice;
            ticket.DateTime = ticketDTO.DateTime;
            ticket.UserId = ticketDTO.User.Id;

            ticketService.Update(ticket);
            ticketService.Save();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteTicket(int id)
        {
            var ticket = ticketService.Get(id);
            if (ticket == null)
            {
                return NotFound();
            }

            ticketService.Delete(ticket);
            ticketService.Save();

            return NoContent();
        }
    }
}

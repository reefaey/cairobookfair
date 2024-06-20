using Cairo_book_fair.Models;
using Cairo_book_fair.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cairo_book_fair.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketRepository ticketRepository;

        public TicketController(ITicketRepository ticketRepository)
        {
            this.ticketRepository = ticketRepository;
        }

        [HttpGet]
        public IActionResult GetAll(string[] includes = null)
        {
            List<Ticket> tickets = ticketRepository.GetAll();
            return Ok(tickets);
        }

        [HttpGet("All")]
        public IActionResult Get(Func<Ticket, bool> where)
        {
            List<Ticket> tickets = ticketRepository.Get(where);
            return Ok(tickets);
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            Ticket ticket = ticketRepository.Get(id);
            if (ticket != null)
            {
                return Ok(ticket);
            }
            return BadRequest();
        }

        [HttpPost]
        public IActionResult Insert(Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                ticketRepository.Insert(ticket);
                ticketRepository.Save();
                return CreatedAtAction("Get", new { id = ticket.Id }, ticket);
            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        public IActionResult Update(Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                ticketRepository.Update(ticket);
                ticketRepository.Save();
                return NoContent();
            }
            return BadRequest(ModelState);
        }

        [HttpDelete]
        public IActionResult Delete(Ticket ticket)
        {
            ticketRepository.Delete(ticket);
            return NoContent();
        }
    }
}

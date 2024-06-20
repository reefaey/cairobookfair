using Cairo_book_fair.DTOs;
using Cairo_book_fair.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Cairo_book_fair.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _ticketService;

        [HttpGet]
        public ActionResult<IEnumerable<TicketDTO>> GetTickets()
        {
            List<TicketDTO> ticketDTOs = _ticketService.GetAllDTO();
            return Ok(ticketDTOs);
        }
    }
}

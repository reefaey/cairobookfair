using Cairo_book_fair.DTOs;
using Cairo_book_fair.Models;
using Cairo_book_fair.Repositories;
using Cairo_book_fair.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;

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

        //[HttpGet]
        //[Authorize]
        //public ActionResult<IEnumerable<TicketDTO>> GetAllTickets()
        //{
        //    var tickets = ticketService.GetAll();
        //    var ticketDTOs = new List<TicketDTO>();

        //    foreach (var ticket in tickets)
        //    {
        //        ticketDTOs.Add(new TicketDTO
        //        {
        //            Id = ticket.Id,
        //            Name = ticket.Name,
        //            Phone = ticket.Phone,
        //            TicketPrice = ticket.Price,
        //            DateTime = ticket.DateTime,
        //        });
        //    }

        //    return Ok(ticketDTOs);
        //}

        [Authorize]
        [HttpGet("Get-Tickt-for-login-user")]
        public ActionResult<TicketDTO> GetTicket()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            TicketDTO? ticketDTO = ticketService.GetDTO(userId);

            if (ticketDTO == null)
            {
                return Ok("عذراً لم يتم العثور على تذكرة");
            }

            return Ok(ticketDTO);
        }

        [Authorize]
        [HttpPost]
        public ActionResult<TicketDTO> CreateTicket(NewTicketDTO newTicketDTO)
        {
            string userName = User.Identity.Name;
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Ticket? ticket = ticketService.Get(userId);
            if(ticket != null)
            {
                return BadRequest("تم حجز تذكرة مسبقاً يمكنك التعديل عليها");
            }
            ticketService.InsertTicket(newTicketDTO, userName, userId);
            ticketService.Save();

            return Ok();
        }

        //[Authorize]
        //[HttpGet("ForEdit")]
        //public IActionResult GetTicketForEdit()
        //{
        //    string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        //    Ticket? ticket = ticketService.Get(userId);

        //    if (ticket == null)
        //    {
        //        return NotFound("Ticket not found");
        //    }

        //    NewTicketDTO newTicketDTO = new NewTicketDTO
        //    {
        //        Phone = ticket.Phone,
        //        NumberOfTicket = ticket.NoofTicket
        //    };

        //    return Ok(newTicketDTO);
        //}


        [Authorize]
        [HttpPut]
        public IActionResult UpdateTicket(NewTicketDTO newTicketDTO)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Ticket? ticket = ticketService.Get(userId);
            if (ticket != null)
            {
                ticketService.UpdateTicket(ticket, newTicketDTO);
                ticketService.Save();
                return Ok("!تم التعديل علي التذكرة بنجاح");
            }

            return NotFound("عذراً لم يتم التعديل على التذكرة"); 
        }
        [Authorize]
        [HttpDelete]
        public IActionResult DeleteTicket()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Ticket? ticket = ticketService.Get(userId);
            if (ticket == null)
            {
                return NotFound("عذراً لم يتم العثور على تذكرة محجوزة");
            }

            ticketService.Delete(ticket);
            ticketService.Save();

            return Ok("!تم الغاء التذكرة بنجاح");
        }
    }
}

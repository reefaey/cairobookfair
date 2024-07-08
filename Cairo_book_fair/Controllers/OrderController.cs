using Cairo_book_fair.DTOs;
using Cairo_book_fair.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cairo_book_fair.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<OrderDto> orders = orderService.GetAll();
            if (orders != null)
            {
                return Ok(orders);
            }
            return NotFound();
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            OrderDto order = orderService.Get(id);

            if (order != null)
            {
                return Ok(order);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult Insert(string UserId)
        {

           orderService.Insert(UserId);

            return Ok();

        }

        //[HttpPut]
        //public IActionResult Update(OrderDto order)
        //{
        //    if (ModelState.IsValid == true)
        //    {
        //        orderService.Update(order);

        //        return Ok();
        //    }

        //    return BadRequest(ModelState);
        //}

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            orderService.Delete(id);
            return NoContent();
        }
    }
}

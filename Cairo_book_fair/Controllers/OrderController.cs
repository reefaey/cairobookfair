using Cairo_book_fair.Models;
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
        public IActionResult GetAll(string? include = null)
        {
            List<Order> orders = orderService.GetAll(include);

            return Ok(orders);
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            Order order = orderService.Get(id);

            if (order != null)
            {
                return Ok(order);
            }

            return BadRequest();
        }

        [HttpPost]
        public IActionResult Insert(Order order)
        {
            if (ModelState.IsValid == true)
            {
                orderService.Insert(order);

                orderService.Save();

                return CreatedAtAction("Get", new { id = order.Id }, order);
            }

            return BadRequest(ModelState);
        }

        [HttpPut]
        public IActionResult Update(Order order)
        {
            if (ModelState.IsValid == true)
            {
                orderService.Update(order);

                orderService.Save();

                return NoContent();
            }

            return BadRequest(ModelState);
        }

        [HttpDelete]
        public IActionResult Delete(Order order)
        {
            orderService.Delete(order);
            return NoContent();
        }
    }
}

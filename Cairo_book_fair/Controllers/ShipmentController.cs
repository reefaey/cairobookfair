using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cairo_book_fair.DTOs;
using Cairo_book_fair.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cairo_book_fair.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipmentController : ControllerBase
    {
        private readonly IShipmentService shipmentService;

        public ShipmentController(IShipmentService shipmentService)
        {
            this.shipmentService = shipmentService;
        }

        // GET: api/Shipment
        [HttpGet]
        public async Task<ActionResult<List<ShipmentDTO>>> GetAllShipmentsAsync()
        {
            var shipments = await shipmentService.GetAllShipmentsAsync();
            return Ok(shipments);
        }

        // GET: api/Shipment/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ShipmentDTO>> GetShipmentByIdAsync(int id)
        {
            var shipment = await shipmentService.GetShipmentByIdAsync(id);
            if (shipment == null)
            {
                return NotFound();
            }
            return Ok(shipment);
        }

        // POST: api/Shipment
        [HttpPost]
        public async Task<IActionResult> CreateShipmentAsync([FromBody] ShipmentDTO shipmentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await shipmentService.CreateShipmentAsync(shipmentDto);
                return CreatedAtAction(nameof(GetShipmentByIdAsync), new { id = shipmentDto.Id }, shipmentDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // PUT: api/Shipment/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateShipmentAsync(int id, [FromBody] ShipmentDTO shipmentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await shipmentService.UpdateShipmentAsync(id, shipmentDto);
                return NoContent();
            }
            catch (ArgumentException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // DELETE: api/Shipment/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShipmentAsync(int id)
        {
            try
            {
                await shipmentService.DeleteShipmentAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}

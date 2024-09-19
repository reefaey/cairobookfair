using Microsoft.AspNetCore.Mvc;
using Cairo_book_fair.DTOs;
using Cairo_book_fair.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cairo_book_fair.Models;

namespace Cairo_book_fair.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipmentsController : ControllerBase
    {
        private readonly IShipmentService _shipmentService;

        public ShipmentsController(IShipmentService shipmentService)
        {
            _shipmentService = shipmentService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShipmentDTO>>> GetShipments()
        {
            var shipments = await _shipmentService.GetAllShipments();
            var shipmentDTOs = shipments.Select(shipment => new ShipmentDTO
            {
                Id = shipment.Id,
                Address = shipment.Address,
                Date = shipment.Date,
                OrderId = shipment.OrderId,
                Status = shipment.Status,
                City = shipment.City,
                Region = shipment.Region,
                PostalCode = shipment.PostalCode,
                UserId = shipment.UserId
            });
            return Ok(shipmentDTOs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ShipmentDTO>> GetShipment(int id)
        {
            var shipment = await _shipmentService.GetShipmentById(id);
            if (shipment == null)
            {
                return NotFound();
            }

            var shipmentDTO = new ShipmentDTO
            {
                Id = shipment.Id,
                Address = shipment.Address,
                Date = shipment.Date,
                OrderId = shipment.OrderId,
                Status = shipment.Status,
                City = shipment.City,
                Region = shipment.Region,
                PostalCode = shipment.PostalCode,
                UserId = shipment.UserId
            };

            return Ok(shipmentDTO);
        }

        [HttpPost]
        public async Task<ActionResult<ShipmentDTO>> PostShipment(ShipmentDTO shipmentDTO)
        {
            var shipment = new Shipment
            {
                Address = shipmentDTO.Address,
                Date = shipmentDTO.Date,
                OrderId = shipmentDTO.OrderId,
                Status = shipmentDTO.Status,
                City = shipmentDTO.City,
                Region = shipmentDTO.Region,
                PostalCode = shipmentDTO.PostalCode,
                UserId = shipmentDTO.UserId
            };

            var createdShipment = await _shipmentService.AddShipment(shipment);

            shipmentDTO.Id = createdShipment.Id;

            return CreatedAtAction(nameof(GetShipment), new { id = createdShipment.Id }, shipmentDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutShipment(int id, ShipmentDTO shipmentDTO)
        {
            if (id != shipmentDTO.Id)
            {
                return BadRequest();
            }

            var shipment = new Shipment
            {
                Id = shipmentDTO.Id,
                Address = shipmentDTO.Address,
                Date = shipmentDTO.Date,
                OrderId = shipmentDTO.OrderId,
                Status = shipmentDTO.Status,
                City = shipmentDTO.City,
                Region = shipmentDTO.Region,
                PostalCode = shipmentDTO.PostalCode,
                UserId = shipmentDTO.UserId
            };

            try
            {
                await _shipmentService.UpdateShipment(shipment);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShipment(int id)
        {
            var shipment = await _shipmentService.GetShipmentById(id);
            if (shipment == null)
            {
                return NotFound();
            }

            await _shipmentService.DeleteShipment(id);

            return NoContent();
        }
    }
}

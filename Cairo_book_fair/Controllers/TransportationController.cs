using Cairo_book_fair.Models;
using Cairo_book_fair.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Cairo_book_fair.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class TransportationController : ControllerBase
    {
        private readonly ITransportationService _transportationService;
        private readonly ILogger<TransportationController> _logger;

        public TransportationController(ITransportationService transportationService, ILogger<TransportationController> logger)
        {
            _transportationService = transportationService;
            _logger = logger;
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public IActionResult GetAll()
        {
            var transportation = _transportationService.GetAll();
            return Ok(transportation);

        }

        [Authorize(Roles = "Admin")]
        [HttpPost("import")]
        public async Task<IActionResult> ImportTransportations([FromQuery] string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                return BadRequest("File path is required");
            }

            _logger.LogInformation($"Received file path: {filePath}");

            if (!System.IO.File.Exists(filePath))
            {
                _logger.LogError($"File not found: {filePath}");
                return NotFound("File not found");
            }

            string jsonString = await System.IO.File.ReadAllTextAsync(filePath);
            _logger.LogInformation($"JSON string read successfully: {jsonString}");

            try
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                var transportationData = JsonSerializer.Deserialize<TransportationData>(jsonString, options);

                if (transportationData == null || transportationData.Lines == null)
                {
                    return BadRequest("Invalid JSON structure");
                }

                var transportations = new List<Transportation>();
                foreach (var line in transportationData.Lines)
                {
                    var transportation = new Transportation
                    {
                        Name = line.Name,
                        routes = line.Route
                    };
                    transportations.Add(transportation);
                }

                _transportationService.AddTransportations(transportations);
                return Ok("Transportations imported successfully");
            }
            catch (JsonException ex)
            {
                _logger.LogError($"Error deserializing JSON: {ex.Message}");
                return BadRequest($"Error deserializing JSON: {ex.Message}");
            }
        }
    }

}

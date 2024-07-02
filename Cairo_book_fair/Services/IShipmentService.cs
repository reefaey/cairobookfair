using Cairo_book_fair.DTOs;

namespace Cairo_book_fair.Services
{
    public interface IShipmentService
    {
        Task<ShipmentDTO> GetShipmentByIdAsync(int id);
        Task<List<ShipmentDTO>> GetAllShipmentsAsync();
        Task CreateShipmentAsync(ShipmentDTO shipmentDto);
        Task UpdateShipmentAsync(int id, ShipmentDTO shipmentDto);
        Task DeleteShipmentAsync(int id);
    }
}

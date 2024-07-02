using Cairo_book_fair.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Cairo_book_fair.Repositories
{
    public interface IShipmentRepository
    {
        Task<Shipment> GetShipmentByIdAsync(int id);
        Task<List<Shipment>> GetAllShipmentsAsync();
        Task CreateShipmentAsync(Shipment shipment);
        Task UpdateShipmentAsync(Shipment shipment);
        Task DeleteShipmentAsync(int id);
    }
}

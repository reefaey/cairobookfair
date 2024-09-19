using Cairo_book_fair.Models;
using Cairo_book_fair.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cairo_book_fair.Services
{
    public class ShipmentService : IShipmentService
    {
        private readonly IShipmentRepository _shipmentRepository;

        public ShipmentService(IShipmentRepository shipmentRepository)
        {
            _shipmentRepository = shipmentRepository;
        }

        public async Task<IEnumerable<Shipment>> GetAllShipments()
        {
            return await _shipmentRepository.GetAllShipments();
        }

        public async Task<Shipment> GetShipmentById(int id)
        {
            return await _shipmentRepository.GetShipmentById(id);
        }

        public async Task<Shipment> AddShipment(Shipment shipment)
        {
            return await _shipmentRepository.AddShipment(shipment);
        }

        public async Task<Shipment> UpdateShipment(Shipment shipment)
        {
            return await _shipmentRepository.UpdateShipment(shipment);
        }

        public async Task<Shipment> DeleteShipment(int id)
        {
            return await _shipmentRepository.DeleteShipment(id);
        }
    }
}

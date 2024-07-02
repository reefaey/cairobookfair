using AutoMapper;
using Cairo_book_fair.DTOs;
using Cairo_book_fair.Models;
using Cairo_book_fair.Repositories;

namespace Cairo_book_fair.Services
{
    public class ShipmentService : IShipmentService
    {
        private readonly IShipmentRepository shipmentRepository;
        private readonly IMapper mapper;

        public ShipmentService(IShipmentRepository shipmentRepository, IMapper mapper)
        {
            this.shipmentRepository = shipmentRepository;
            this.mapper = mapper;
        }

        public async Task<ShipmentDTO> GetShipmentByIdAsync(int id)
        {
            var shipment = await shipmentRepository.GetShipmentByIdAsync(id);
            return mapper.Map<ShipmentDTO>(shipment);
        }

        public async Task<List<ShipmentDTO>> GetAllShipmentsAsync()
        {
            var shipments = await shipmentRepository.GetAllShipmentsAsync();
            return mapper.Map<List<ShipmentDTO>>(shipments);
        }

        public async Task CreateShipmentAsync(ShipmentDTO shipmentDto)
        {
            var shipment = mapper.Map<Shipment>(shipmentDto);
            await shipmentRepository.CreateShipmentAsync(shipment);
        }

        public async Task UpdateShipmentAsync(int id, ShipmentDTO shipmentDto)
        {
            var existingShipment = await shipmentRepository.GetShipmentByIdAsync(id);
            if (existingShipment == null)
            {
                throw new ArgumentException("Shipment not found");
            }

            mapper.Map(shipmentDto, existingShipment);
            await shipmentRepository.UpdateShipmentAsync(existingShipment);
        }

        public async Task DeleteShipmentAsync(int id)
        {
            await shipmentRepository.DeleteShipmentAsync(id);
        }
    }
}

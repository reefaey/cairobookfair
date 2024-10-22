﻿using Cairo_book_fair.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cairo_book_fair.Services
{
    public interface IShipmentService
    {
        Task<IEnumerable<Shipment>> GetAllShipments();
        Task<Shipment> GetShipmentById(int id);
        Task<Shipment> AddShipment(Shipment shipment);
        Task<Shipment> UpdateShipment(Shipment shipment);
        Task<Shipment> DeleteShipment(int id);
    }
}

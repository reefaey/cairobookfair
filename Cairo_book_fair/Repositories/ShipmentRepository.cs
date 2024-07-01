using Cairo_book_fair.DBContext;
using Cairo_book_fair.Models;
using Google;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cairo_book_fair.Repositories
{
    public class ShipmentRepository : IShipmentRepository
    {
        private readonly Context context;

        public ShipmentRepository(Context context)
        {
            this.context = context;
        }

        public async Task<Shipment> GetShipmentByIdAsync(int id)
        {
            return await context.Shipments.FindAsync(id);
        }

        public async Task<List<Shipment>> GetAllShipmentsAsync()
        {
            return await context.Shipments.ToListAsync();
        }

        public async Task CreateShipmentAsync(Shipment shipment)
        {
            context.Shipments.Add(shipment);
            await context.SaveChangesAsync();
        }

        public async Task UpdateShipmentAsync(Shipment shipment)
        {
            context.Entry(shipment).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task DeleteShipmentAsync(int id)
        {
            var shipment = await context.Shipments.FindAsync(id);
            if (shipment != null)
            {
                context.Shipments.Remove(shipment);
                await context.SaveChangesAsync();
            }
        }
    }
}


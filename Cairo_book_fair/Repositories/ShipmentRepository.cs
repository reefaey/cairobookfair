using Cairo_book_fair.DBContext;
using Cairo_book_fair.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cairo_book_fair.Repositories
{
    public class ShipmentRepository : IShipmentRepository
    {
        private readonly Context _context;

        public ShipmentRepository(Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Shipment>> GetAllShipments()
        {
            return await _context.Shipments.Include(s => s.Order).Include(s => s.User).ToListAsync();
        }

        public async Task<Shipment> GetShipmentById(int id)
        {
            var shipment = await _context.Shipments.Include(s => s.Order).Include(s => s.User)
                                                   .FirstOrDefaultAsync(s => s.Id == id);
            if (shipment == null)
            {
                throw new KeyNotFoundException($"Shipment with id {id} not found.");
            }
            return shipment;
        }

        public async Task<Shipment> AddShipment(Shipment shipment)
        {
            _context.Shipments.Add(shipment);
            await _context.SaveChangesAsync();
            return shipment;
        }

        public async Task<Shipment> UpdateShipment(Shipment shipment)
        {
            _context.Entry(shipment).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return shipment;
        }

        public async Task<Shipment> DeleteShipment(int id)
        {
            var shipment = await _context.Shipments.FindAsync(id);
            if (shipment != null)
            {
                _context.Shipments.Remove(shipment);
                await _context.SaveChangesAsync();
            }
            return shipment;
        }
    }
}

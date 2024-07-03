using Cairo_book_fair.DBContext;
using Cairo_book_fair.Models;

public class TransportationRepository : ITransportationRepository
{
    private readonly Context _context;
    public TransportationRepository(Context context)
    {
        _context = context;
    }

    public List<Transportation> AddTransportations(IEnumerable<Transportation> transportations)
    {
        _context.Transportations.AddRange(transportations);
        _context.SaveChanges();
        return transportations.ToList();
    }

    public List<Transportation> GetAll()
    {
        return _context.Transportations.ToList();
    }
}
using Cairo_book_fair.Models;

public interface ITransportationRepository
{
    public List<Transportation> GetAll();
    public List<Transportation> AddTransportations(IEnumerable<Transportation> transportations);
}
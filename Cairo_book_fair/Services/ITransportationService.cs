
using Cairo_book_fair.Models;

namespace Cairo_book_fair.Services.Interfaces;
public interface ITransportationService
{
    List<TransportationDTO> GetAll();

    List<TransportationDTO> AddTransportations(IEnumerable<Transportation> transportations);
}

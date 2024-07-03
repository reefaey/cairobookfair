using AutoMapper;
using Cairo_book_fair.Models;
using Cairo_book_fair.Services.Interfaces;

public class TransportationService : ITransportationService
{
    private readonly ITransportationRepository _transportationRepository;
    private readonly IMapper _mapper;
    public TransportationService(ITransportationRepository transportationRepository, IMapper mapper)
    {
        _transportationRepository = transportationRepository;
        _mapper = mapper;
    }

    public List<TransportationDTO> AddTransportations(IEnumerable<Transportation> transportations)
    {
        var trasponsrtations = _transportationRepository.AddTransportations(transportations);
        return _mapper.Map<List<TransportationDTO>>(trasponsrtations);
    }

    public List<TransportationDTO> GetAll()
    {
        var transportation = _transportationRepository.GetAll();
        return _mapper.Map<List<TransportationDTO>>(transportation);
    }
}
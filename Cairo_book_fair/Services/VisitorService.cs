using AutoMapper;
using Cairo_book_fair.Models;
using Cairo_book_fair.Services.Interfaces;

namespace Cairo_book_fair.Services;
public class VisitorService : IVisitorsService
{
    private readonly IVisitorRepository _visitorsRepository;
    private readonly IMapper _mapper;

    public VisitorService(IMapper mapper, IVisitorRepository visitorsRepository)
    {

        _mapper = mapper;
        _visitorsRepository = visitorsRepository;
    }

    public List<Visitors> GetAll()
    {
        var visitors = _visitorsRepository.GetAll();
        return visitors;
    }

    public VisitorsDTO Add(VisitorsDTO visitorsDTO)
    {
        var visitors = _mapper.Map<Visitors>(visitorsDTO);

        return _mapper.Map<VisitorsDTO>(_visitorsRepository.Add(visitors));
    }


    VisitorsDTO IVisitorsService.Update(int id, VisitorsDTO visitorsDTO)
    {
        var visitors = _mapper.Map<Visitors>(visitorsDTO);

        return _mapper.Map<VisitorsDTO>(_visitorsRepository.Update(id, visitors));

    }
}
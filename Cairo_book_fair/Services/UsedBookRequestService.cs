using AutoMapper;
using Cairo_book_fair.DBContext;
using Cairo_book_fair.DTOs;
using Cairo_book_fair.Models;
using Cairo_book_fair.Repositories;

namespace Cairo_book_fair.Services
{
    public class UsedBookRequestService : Service<UsedBookRequest>, IUsedBookRequestService
    {
        private readonly IUsedBookRequestRepository _usedBookReqRepository;
        private readonly IMapper _mapper;
        public UsedBookRequestService(IUsedBookRequestRepository usedBookReqRepository, IRepository<UsedBookRequest> repository) : base(repository)
        {
            _usedBookReqRepository = usedBookReqRepository;
        }

        //private readonly IRepository<UsedBookRequest> _repository;
        //public UsedBookRequestService(IRepository<UsedBookRequest> repository, IMapper mapper) :base(repository)
        //{
        //    _repository = repository;
        //    _mapper = mapper;
        //}

        public void SendRequest(string userId, UsedBookDtoInsert usedBookDtoInsert)
        {
            UsedBookRequest usedBookRequest = _mapper.Map<UsedBookRequest>(usedBookDtoInsert);
            usedBookRequest.UserId = userId;
            usedBookRequest.BookCondition = Enums.Condition.Used;
            _usedBookReqRepository.Insert(usedBookRequest);
            _usedBookReqRepository.Save();
        }

        public List<UsedbookRequestWithStatus>? GetAllUserRequests(string userId)
        {
            List<UsedbookRequestWithStatus>? usedBookRequests = _usedBookReqRepository.GetAllUserRequest(userId);
            //if(usedBookRequests.Any())
            if(usedBookRequests != null)
            {
                List<UsedbookRequestWithStatus> usedbookRequestWithStatus = new();
                foreach(UsedBookRequest usedBookRequest in usedBookRequests)
                {
                    usedBookRequests.Add(
                        new UsedbookRequestWithStatus()
                    
                    
                        );
                }
            }

            return null;
        }

        public void CancelRequest(string userId, UsedBookDtoInsert usedBookDtoInsert)
        {
            UsedBookRequest usedBookRequest = _mapper.Map<UsedBookRequest>(usedBookDtoInsert);
            usedBookRequest.UserId = userId;
            usedBookRequest.BookCondition = Enums.Condition.Used;
            _usedBookReqRepository.Insert(usedBookRequest);
            _usedBookReqRepository.Save();
        }

    }
}

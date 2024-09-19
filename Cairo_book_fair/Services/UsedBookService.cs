using AutoMapper;
using Cairo_book_fair.DTOs;
using Cairo_book_fair.Models;
using Cairo_book_fair.Repositories;
using System.Security.Claims;

namespace Cairo_book_fair.Services
{
    public class UsedBookService : IUsedBookService
    {
        private readonly IUsedBookRepository usedBookRepository;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;

        public UsedBookService(IUsedBookRepository usedBookRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            this.usedBookRepository = usedBookRepository;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
        }

        private string GetCurrentUserId()
        {
            return httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
        private string GetCurrentUserName()
        {
            return httpContextAccessor.HttpContext.User.Identity.Name;
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void Insert(UsedBookForInsert usedBookDto)
        {
            UsedBook usedBook = mapper.Map<UsedBook>(usedBookDto);
            var userId = GetCurrentUserId();
            var userName = GetCurrentUserName();
            usedBook.UserId = userId;
            var user = usedBookRepository.GetUserById(userId);
            usedBook.DonorName = userName;
            usedBookRepository.Insert(usedBook);
            usedBook.User.NumberOfDonatedBooks++;
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////
        public void Update(int id, UsedBookForInsert usedBookDto)
        {
            UsedBook usedBookDB = usedBookRepository.Get(id);
            if (usedBookDB != null)
            {
                mapper.Map(usedBookDto, usedBookDB);
                usedBookDB.UserId = GetCurrentUserId();
                usedBookDB.DonorName = GetCurrentUserName();
                usedBookRepository.Update(usedBookDB);
            }
            else
            {
                throw new KeyNotFoundException($"This UsedBook with Id :{id} was not found.");

            }

        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////
        public void Delete(int id)
        {
            UsedBook usedBook = usedBookRepository.Get(id);
            if (usedBook != null)
            {
                usedBookRepository.Delete(usedBook);
            }
            else
            {
                throw new KeyNotFoundException($"This UsedBook with Id :{id} was not found.");

            }

        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public void Save()
        {
            usedBookRepository.Save();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public PaginatedList<UsedBookDto> GetPaginatedBooks(int page, int pageSize, string[] include = null)
        {
            PaginatedList<UsedBook> paginatedList = usedBookRepository.GetPaginatedBooks(page, pageSize, include);
            IEnumerable<UsedBookDto> usedBookDtos = mapper.Map<IEnumerable<UsedBookDto>>(paginatedList.Items);
            PaginatedList<UsedBookDto> paginatedListDto = new()
            {
                TotalPages = paginatedList.TotalPages,
                TotalItems = paginatedList.TotalItems,
                CurrentPage = paginatedList.CurrentPage,
                Items = usedBookDtos
            };
            return paginatedListDto;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////   

        public UsedBookDto Get(int id)
        {
            UsedBook usedBook = usedBookRepository.Get(id);
            UsedBookDto usedBookDto = mapper.Map<UsedBookDto>(usedBook);
            return usedBookDto;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public List<UsedBookDto> Search(string SearchBookName)
        {
            List<UsedBook> booksDB = usedBookRepository.Search(SearchBookName);
            List<UsedBookDto> booksDTO = mapper.Map<List<UsedBookDto>>(booksDB);
            return booksDTO;
        }
    }
}

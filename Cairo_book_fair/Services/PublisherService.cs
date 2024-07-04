using AutoMapper;
using Cairo_book_fair.DTOs;
using Cairo_book_fair.Models;
using Cairo_book_fair.Repositories;

namespace Cairo_book_fair.Services
{
    public class PublisherServicem : IPublisherService
    {
        private readonly IPublisherRepository publisherRepository;
        private readonly IMapper mapper;

        public PublisherServicem(IPublisherRepository publisherRepository, IMapper mapper)
        {
            this.publisherRepository = publisherRepository;
            this.mapper = mapper;
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public void Delete(int id)
        {
            Publisher publisherDb = publisherRepository.Get(id);
            if (publisherDb != null)
            {
                publisherRepository.Delete(publisherDb);
            }
            else
            {
                throw new KeyNotFoundException($"This Publisher with Id :{id} was not found.");

            }
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////////
        public PublisherDto Get(int id, string[] include = null)
        {
            string[] includeProperties = { "Block", "Books" };

            Publisher publisherDB = publisherRepository.Get(id, includeProperties);
            PublisherDto publisherDTO = mapper.Map<PublisherDto>(publisherDB);
            return publisherDTO;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////
        public PaginatedList<PublisherDto> GetPaginatedPublisher(int page, int pageSize, string[] include = null)
        {
            string[] includeProperties = { "Block", "Books" };
            PaginatedList<Publisher> paginatedList = publisherRepository.GetPaginatedPublisher(page, pageSize, includeProperties);
            IEnumerable<PublisherDto> publisherDTOs = mapper.Map<IEnumerable<PublisherDto>>(paginatedList.Items);
            PaginatedList<PublisherDto> paginatedListDTO = new()
            {
                TotalPages = paginatedList.TotalPages,
                TotalItems = paginatedList.TotalItems,
                CurrentPage = paginatedList.CurrentPage,
                Items = publisherDTOs
            };
            return paginatedListDTO;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////

        public void Insert(PublisherDtoForInsert publisherDTO)
        {
            Publisher publisherDB = mapper.Map<Publisher>(publisherDTO);
            publisherRepository.Insert(publisherDB);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////
        public void Save()
        {
            publisherRepository.Save();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////
        public void Update(int id, PublisherDtoForInsert item)
        {
            Publisher publisherDB = publisherRepository.Get(id);
            if (publisherDB != null)
            {
                mapper.Map(item, publisherDB);
                publisherRepository.Update(publisherDB);
            }
            else
            {
                throw new KeyNotFoundException($"This Publisher with Id :{id} was not found.");
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////
        public List<PublisherDto> Search(string SearchPublisherName)
        {
            List<Publisher> publishersDB = publisherRepository.Search(SearchPublisherName);
            List<PublisherDto> publishersDTO = mapper.Map<List<PublisherDto>>(publishersDB);
            return publishersDTO;

        }
    }
}

using Cairo_book_fair.DTOs;

namespace Cairo_book_fair.Services
{
    public interface IPublisherService
    {
        public PaginatedList<PublisherDto> GetPaginatedPublisher(int page, int pageSize, string[] include = null);
        public PublisherDto Get(int id, string[] include = null);
        void Insert(PublisherDtoForInsert item);
        void Update(int id, PublisherDtoForInsert item);
        void Delete(int id);
        public void Save();
        public List<PublisherDto> Search(string SearchBookName);
        public List<BookDTO> GetPublisherBooks(int publisherID);
    }
}

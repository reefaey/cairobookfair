using Cairo_book_fair.DTOs;
using Cairo_book_fair.Models;

namespace Cairo_book_fair.Repositories
{
    public interface IPublisherRepository
    {
        public Publisher Get(int id, string[] include = null);
        public PaginatedList<Publisher> GetPaginatedPublisher(int page, int pageSize, string[] include = null);
        void Insert(Publisher item);
        void Update(Publisher item);
        void Delete(Publisher item);
        public void Save();
        public List<Publisher> Search(string SearchBookName);
        public List<Book> GetPublisherBooks(int publisherID);
    }
}

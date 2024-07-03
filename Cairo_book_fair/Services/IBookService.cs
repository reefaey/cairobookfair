using Cairo_book_fair.DTOs;

namespace Cairo_book_fair.Services
{
    public interface IBookService
    {

        public PaginatedList<BookWithDetails> GetPaginatedBooks(int page, int pageSize, string[] include = null);
        BookWithDetails Get(int id, string[] include = null);
        void Insert(BookDTO item);
        void Update(int id, BookDTO item);
        void Delete(int id);
        public void Save();
        public List<BookWithDetails> Search(string SearchBookName);


    }
}

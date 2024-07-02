using Cairo_book_fair.DTOs;
using Cairo_book_fair.Models;

namespace Cairo_book_fair.Services
{
    public interface IBookService
    {

        public PaginatedList<BookWithDetails> GetPaginatedBooks(int page = 1, int pageSize = 10, string[] include = null);
        public List<BookWithDetails> GetAll(string[] include = null);
        List<Book> Get(Func<Book, bool> where);
        BookWithDetails Get(int id, string[] include = null);
        void Insert(BookDTO item);
        void Update(int id, BookDTO item);
        void Delete(int id);
        public void Save();
        public List<BookWithDetails> Search(string SearchBookName);


    }
}

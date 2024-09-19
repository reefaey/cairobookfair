using Cairo_book_fair.DTOs;
using Cairo_book_fair.Models;

namespace Cairo_book_fair.Repositories
{
    public interface IBookRepository
    {
        public List<Book> GetAll(string[] include = null);
        List<Book> Get(Func<Book, bool> where);
        Book Get(int id, string[] include = null);
        Book GetUsedBook(int id, string[] include = null);
        public PaginatedList<Book> GetPaginatedBooks(int page, int pageSize, string[] include = null);
        public PaginatedList<Book> GetPaginatedUsedBooks(int page, int pageSize, string[] include = null);
        void Insert(Book item);
        void Update(Book item);
        void Delete(Book item);
        public void Save();
        public List<Book> Search(string SearchBookName);

        public List<Review> GetBooksReviews(int bookid);
        public List<Book> SearchUsedBook(string SearchBookName);
        User GetUserById(string userId);
    }
}

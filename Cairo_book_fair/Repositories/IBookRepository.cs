using Cairo_book_fair.Models;

namespace Cairo_book_fair.Repositories
{
    public interface IBookRepository : IRepository<Book>
    {
        public List<Book> GetAll(string[] include = null);
        Book Get(int id, string[] include = null);

        public List<Book> Search(string SearchBookName);
    }
}

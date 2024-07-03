using Cairo_book_fair.DTOs;
using Cairo_book_fair.Models;

namespace Cairo_book_fair.Repositories
{
    public interface IUsedBookRepository
    {
        public List<UsedBook> GetAll(string[] include = null);
        List<UsedBook> Get(Func<UsedBook, bool> where);
        UsedBook Get(int id);
        User GetUserById(string userId);
        public PaginatedList<UsedBook> GetPaginatedBooks(int page, int pageSize, string[] include = null);
        void Insert(UsedBook item);
        void Update(UsedBook item);
        void Delete(UsedBook item);
        public void Save();
        public List<UsedBook> Search(string SearchBookName);
    }
}

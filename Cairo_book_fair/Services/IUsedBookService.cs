using Cairo_book_fair.DTOs;

namespace Cairo_book_fair.Services
{
    public interface IUsedBookService
    {
        public PaginatedList<UsedBookDto> GetPaginatedBooks(int page, int pageSize, string[] include = null);
        UsedBookDto Get(int id);
        void Insert(UsedBookForInsert item);
        void Update(int id, UsedBookForInsert item);
        void Delete(int id);
        public void Save();
        public List<UsedBookDto> Search(string SearchBookName);
    }
}

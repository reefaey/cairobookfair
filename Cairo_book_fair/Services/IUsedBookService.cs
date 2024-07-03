using Cairo_book_fair.DTOs;

namespace Cairo_book_fair.Services
{
    public interface IUsedBookService
    {
        public PaginatedList<UsedBookDto> GetPaginatedBooks(int page = 1, int pageSize = 10, string[] include = null);
        UsedBookDto Get(int id, string[] include = null);
        void Insert(UsedBookDto item);
        void Update(int id, UsedBookDto item);
        void Delete(int id);
        public void Save();
        public List<UsedBookDto> Search(string SearchBookName);
    }
}

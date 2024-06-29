using Cairo_book_fair.DTOs;
using Cairo_book_fair.Models;
using Cairo_book_fair.Repositories;

namespace Cairo_book_fair.Services
{
    public class UsedBookService : IUsedBookService
    {
        private readonly IUsedBookRepository usedBookRepository;

        public UsedBookService(IUsedBookRepository usedBookRepository)
        {
            this.usedBookRepository = usedBookRepository;
        }
        public void Delete(UsedBook item)
        {
            usedBookRepository.Delete(item);
        }

        public List<UsedBook> Get(Func<UsedBook, bool> where)
        {
            return usedBookRepository.Get(where);
        }

        public UsedBook Get(int id, string[] include = null)
        {
            return usedBookRepository.Get(id, include);
        }

        public List<UsedBook> GetAll(string[] include = null)
        {
            return usedBookRepository.GetAll(include);
        }

        public PaginatedList<UsedBook> GetPaginatedBooks(int page = 1, int pageSize = 10, string[] include = null)
        {
            return usedBookRepository.GetPaginatedBooks(page, pageSize, include);
        }

        public void Insert(UsedBook item)
        {
            usedBookRepository.Insert(item);
        }

        public void Save()
        {
            usedBookRepository.Save();
        }

        public List<UsedBook> Search(string SearchBookName)
        {
            return usedBookRepository.Search(SearchBookName);
        }

        public void Update(UsedBook item)
        {
            usedBookRepository.Update(item);
        }
    }
}

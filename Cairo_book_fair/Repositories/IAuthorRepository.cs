using Cairo_book_fair.Models;

namespace Cairo_book_fair.Repositories
{
    public interface IAuthorRepository : IRepository<Author>
    {
        public List<Author> GetSearchResult(string term);

    }
}



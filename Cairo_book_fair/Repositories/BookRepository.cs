using Cairo_book_fair.DBContext;
using Cairo_book_fair.DTOs;
using Cairo_book_fair.Models;
using Microsoft.EntityFrameworkCore;

namespace Cairo_book_fair.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly Context context;

        public BookRepository(Context context)
        {
            this.context = context;
        }


        public void Delete(Book item)
        {
            context.Remove(item);
        }

        public Book Get(int id, string[] include = null)
        {
            IQueryable<Book> query = context.Books;
            if (include != null)
            {
                foreach (var navigationProperty in include)
                {
                    query = query.Include(navigationProperty);
                }
            }
            return query.FirstOrDefault(b => b.Id == id);
        }

        public List<Book> Get(Func<Book, bool> where)
        {
            return context.Books.Where(where).ToList();
        }

        public List<Book> GetAll(string[] include = null)
        {
            IQueryable<Book> query = context.Books;
            if (include != null)
            {
                foreach (var navigationProperty in include)
                {
                    query = query.Include(navigationProperty);
                }
            }
            return query.ToList();
        }
        public PaginatedList<Book> GetPaginatedBooks(int page, int pageSize, string[] include = null)
        {
            IQueryable<Book> query = context.Books;
            if (include != null)
            {
                foreach (var navigationProperty in include)
                {
                    query = query.Include(navigationProperty);
                }
            }

            if (page < 1)
            {
                page = 1;
            }
            //pagination
            int NoOfPages = (int)Math.Ceiling(query.Count() / (double)pageSize);
            int NoOfRecordsToSkip = (page - 1) * pageSize;
            query = query.Skip(NoOfRecordsToSkip).Take(pageSize);

            if (page > NoOfPages)
            {
                page = NoOfPages;
            }
            if (NoOfPages == 0)
            {
                return new PaginatedList<Book>()
                {
                    Items = null,
                    TotalItems = 0,
                    TotalPages = 0,
                    CurrentPage = 0
                };
            }



            return new PaginatedList<Book>
            {
                Items = query.ToList(),
                TotalItems = query.Count(),
                TotalPages = NoOfPages,
                CurrentPage = page

            };
        }

        public List<Book> Search(string SearchBookName)
        {
            List<Book> filteredBooks = context.Books
                .Include(b => b.Publisher).ThenInclude(p => p.Block).ThenInclude(f => f.Hall)
                .Include(b => b.Author)
            .Where(b => b.Name.Contains(SearchBookName)).ToList();

            return filteredBooks;

        }

        public void Insert(Book item)
        {
            context.Add(item);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(Book item)
        {
            context.Update(item);
        }
    }
}

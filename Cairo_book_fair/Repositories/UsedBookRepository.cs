using Cairo_book_fair.DBContext;
using Cairo_book_fair.DTOs;
using Cairo_book_fair.Models;
using Microsoft.EntityFrameworkCore;

namespace Cairo_book_fair.Repositories
{
    public class UsedBookRepository : IUsedBookRepository
    {
        private readonly Context context;

        public UsedBookRepository(Context context)
        {
            this.context = context;
        }


        public void Delete(UsedBook item)
        {
            context.Remove(item);
        }

        public UsedBook Get(int id, string[] include = null)
        {
            IQueryable<UsedBook> query = context.UsedBooks;
            if (include != null)
            {
                foreach (var navigationProperty in include)
                {
                    query = query.Include(navigationProperty);
                }
            }
            return query.FirstOrDefault(b => b.Id == id);
        }

        public List<UsedBook> Get(Func<UsedBook, bool> where)
        {
            return context.UsedBooks.Where(where).ToList();
        }

        public List<UsedBook> GetAll(string[] include = null)
        {
            IQueryable<UsedBook> query = context.UsedBooks;
            if (include != null)
            {
                foreach (var navigationProperty in include)
                {
                    query = query.Include(navigationProperty);
                }
            }
            return query.ToList();
        }
        public PaginatedList<UsedBook> GetPaginatedBooks(int page = 1, int pageSize = 10, string[] include = null)
        {
            IQueryable<UsedBook> query = context.UsedBooks;
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
                return new PaginatedList<UsedBook>()
                {
                    Items = null,
                    TotalItems = 0,
                    TotalPages = 0,
                    CurrentPage = 0
                };
            }



            return new PaginatedList<UsedBook>
            {
                Items = query.ToList(),
                TotalItems = query.Count(),
                TotalPages = NoOfPages,
                CurrentPage = page

            };
        }

        public List<UsedBook> Search(string SearchBookName)
        {
            List<UsedBook> filteredBooks = context.UsedBooks
            .Where(b => b.Name.Contains(SearchBookName)).ToList();

            return filteredBooks;

        }

        public void Insert(UsedBook item)
        {
            context.Add(item);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(UsedBook item)
        {
            context.Update(item);
        }
    }

}


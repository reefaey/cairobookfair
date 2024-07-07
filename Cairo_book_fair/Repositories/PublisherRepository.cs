using Cairo_book_fair.DBContext;
using Cairo_book_fair.DTOs;
using Cairo_book_fair.Models;
using Microsoft.EntityFrameworkCore;

namespace Cairo_book_fair.Repositories
{
    public class PublisherRepository : IPublisherRepository
    {
        private readonly Context context;

        public PublisherRepository(Context context)
        {
            this.context = context;
        }

        public void Delete(Publisher item)
        {
            context.Remove(item);
        }

        public Publisher Get(int id, string[] include = null)
        {
            IQueryable<Publisher> query = context.Publishers;
            if (include != null)
            {
                foreach (var navigationProperty in include)
                {
                    query = query.Include(navigationProperty);
                }
            }
            return query.FirstOrDefault(b => b.Id == id);
        }

        public List<Book> GetPublisherBooks(int publisherID)
        {
            return context.Books
                .Include(b => b.Publisher)
                .Include(b => b.Author)
                .Include(b => b.Reviews)
                .Include(b => b.BookCarts)
                .Include(b => b.BookOrders)
                .Include(b => b.BookCategories)
                .Where(b => b.PublisherId == publisherID)
                .ToList();
        }
        public PaginatedList<Publisher> GetPaginatedPublisher(int page, int pageSize, string[] include = null)
        {
            IQueryable<Publisher> query = context.Publishers;
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
                return new PaginatedList<Publisher>()
                {
                    Items = null,
                    TotalItems = 0,
                    TotalPages = 0,
                    CurrentPage = 0
                };
            }



            return new PaginatedList<Publisher>
            {
                Items = query.ToList(),
                TotalItems = query.Count(),
                TotalPages = NoOfPages,
                CurrentPage = page

            };
        }

        public List<Publisher> Search(string SearchBookName)
        {
            List<Publisher> filteredBooks = context.Publishers
            .Where(b => b.Name.Contains(SearchBookName)).ToList();

            return filteredBooks;

        }

        public void Insert(Publisher item)
        {
            context.Add(item);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(Publisher item)
        {
            context.Update(item);
        }
    }
}

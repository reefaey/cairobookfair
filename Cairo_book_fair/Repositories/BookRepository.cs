using Cairo_book_fair.DBContext;
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

        public Book Get(int id)
        {
            throw new NotImplementedException();
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

        public List<Book> GetAll(string include = null)
        {
            throw new NotImplementedException();
        }
        public List<Book> Search(string SearchBookName)
        {
            List<Book> filteredBooks = context.Books
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

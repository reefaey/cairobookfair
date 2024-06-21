using Cairo_book_fair.Models;
using Cairo_book_fair.Repositories;

namespace Cairo_book_fair.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }
        public void Delete(Book item)
        {
            bookRepository.Delete(item);
        }

        public Book Get(int id)
        {
            return bookRepository.Get(id);
        }

        public List<Book> Get(Func<Book, bool> where)
        {
            return bookRepository.Get(where).ToList();
        }

        public List<Book> GetAll(string include = null)
        {
            return bookRepository.GetAll(include);
        }

        public void Insert(Book item)
        {
            bookRepository.Insert(item);
        }

        public void Save()
        {
            bookRepository.Save();
        }

        public void Update(Book item)
        {
            bookRepository.Update(item);
        }
    }
}

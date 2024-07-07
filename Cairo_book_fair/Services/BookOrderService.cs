using Cairo_book_fair.Models;
using Cairo_book_fair.Repositories;

namespace Cairo_book_fair.Services
{
    public class BookOrderService : IBookOrderService
    {
        private readonly IBookOrderRepository bookOrderRepository;

        public BookOrderService(IBookOrderRepository bookOrderRepository)
        {
            this.bookOrderRepository = bookOrderRepository;
        }
        public void Delete(BookOrder item)
        {
            bookOrderRepository.Delete(item);
        }

        public BookOrder Get(int id)
        {
            return bookOrderRepository.Get(id);
        }

        public List<BookOrder> Get(Func<BookOrder, bool> where)
        {
            return bookOrderRepository.Get(where);
        }

        public List<BookOrder> GetAll(string include = null)
        {
            return bookOrderRepository.GetAll(include);
        }

        public void Insert(BookOrder item)
        {
            bookOrderRepository.Insert(item);
        }

        public void Save()
        {
            bookOrderRepository.Save();
        }

        public void Update(BookOrder item)
        {
            bookOrderRepository.Update(item);
        }
    }
}

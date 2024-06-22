using AutoMapper;
using Cairo_book_fair.DTOs;
using Cairo_book_fair.Models;
using Cairo_book_fair.Repositories;

namespace Cairo_book_fair.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository bookRepository;
        private readonly IMapper mapper;
        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            this.bookRepository = bookRepository;
            this.mapper = mapper;
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public void Delete(Book item)
        {
            bookRepository.Delete(item);
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public List<Book> Get(Func<Book, bool> where)
        {
            return bookRepository.Get(where).ToList();
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////////
        public BookWithDetails Get(int id, string[] include = null)
        {
            Book bookDB = bookRepository.Get(id, include);
            BookWithDetails bookDTO = mapper.Map<BookWithDetails>(bookDB);
            return bookDTO;
        }
        ///////////////////////////////////////,///////////////////////////////////////////////////////////
        public List<BookWithDetails> GetAll(string[] include = null)
        {
            List<Book> booksDB = bookRepository.GetAll(include);
            List<BookWithDetails> booksDTO = mapper.Map<List<BookWithDetails>>(booksDB);
            return booksDTO;
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////
        public PaginatedList<BookWithDetails> GetPaginatedBooks(int page = 1, int pageSize = 10, string[] include = null)
        {
            PaginatedList<Book> paginatedList = bookRepository.GetPaginatedBooks(page, pageSize, include);
            IEnumerable<BookWithDetails> booksDTOs = mapper.Map<IEnumerable<BookWithDetails>>(paginatedList.Items);
            PaginatedList<BookWithDetails> paginatedListDTO = new()
            {
                TotalPages = paginatedList.TotalPages,
                TotalItems = paginatedList.TotalItems,
                CurrentPage = paginatedList.CurrentPage,
                Items = booksDTOs
            };
            return paginatedListDTO;
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////

        public void Insert(Book item)
        {
            bookRepository.Insert(item);
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////
        public void Save()
        {
            bookRepository.Save();
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////
        public List<BookWithDetails> Search(string SearchBookName)
        {
            List<Book> booksDB = bookRepository.Search(SearchBookName);
            List<BookWithDetails> booksDTO = mapper.Map<List<BookWithDetails>>(booksDB);
            return booksDTO;

        }
        //////////////////////////////////////////////////////////////////////////////////////////////////
        public void Update(Book item)
        {
            bookRepository.Update(item);
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////////

    }
}

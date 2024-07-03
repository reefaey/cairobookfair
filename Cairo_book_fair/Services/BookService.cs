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
        public void Delete(int id)
        {
            Book bookDb = bookRepository.Get(id);
            if (bookDb != null)
            {
                bookRepository.Delete(bookDb);
            }
            else
            {
                throw new KeyNotFoundException($"This Book with Id :{id} was not found.");

            }
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////
        public BookWithDetails Get(int id, string[] include = null)
        {
            string[] includeProperties = { "Author", "BookCategories.Category", "Publisher.Block.Hall" };

            Book bookDB = bookRepository.Get(id, includeProperties);
            BookWithDetails bookDTO = mapper.Map<BookWithDetails>(bookDB);
            return bookDTO;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////
        public PaginatedList<BookWithDetails> GetPaginatedBooks(int page, int pageSize, string[] include = null)
        {
            string[] includeProperties = { "Author", "BookCategories.Category", "Publisher.Block.Hall" };
            PaginatedList<Book> paginatedList = bookRepository.GetPaginatedBooks(page, pageSize, includeProperties);
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
        ///
        //////////////////////////////////////////////////////////////////////////////////////////////////

        public void Insert(BookDTO bookDTO)
        {
            Book bookDB = mapper.Map<Book>(bookDTO);
            bookRepository.Insert(bookDB);
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
        public void Update(int id, BookDTO item)
        {
            Book bookDB = bookRepository.Get(id);
            if (bookDB != null)
            {
                mapper.Map(item, bookDB);
                bookRepository.Update(bookDB);
            }
            else
            {
                throw new KeyNotFoundException($"This Book with Id :{id} was not found.");
            }
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////////

    }
}

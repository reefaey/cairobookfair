using AutoMapper;
using Cairo_book_fair.DTOs;
using Cairo_book_fair.Models;
using Cairo_book_fair.Repositories;
using System.Net;
using System.Security.Claims;


namespace Cairo_book_fair.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository bookRepository;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;

        public BookService(IBookRepository bookRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            this.bookRepository = bookRepository;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
        }

        private string GetCurrentUserId()
        {
            return httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
        private string GetCurrentUserName()
        {
            return httpContextAccessor.HttpContext.User.Identity.Name;
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

        public List<ReviewDTO> GetBooksReviews(int bookid)
        {
            List<Review> bookReviews = bookRepository.GetBooksReviews(bookid);
            List<ReviewDTO> reviewDTOs = mapper.Map<List<ReviewDTO>>(bookReviews);

            return reviewDTOs;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public void DeleteUsedBook(int id)
        {
            Book bookDb = bookRepository.GetUsedBook(id);
            if (bookDb != null)
            {
                var userId = GetCurrentUserId();
                var userName = GetCurrentUserName();
                bookDb.UserId = userId;
                var user = bookRepository.GetUserById(userId);
                bookDb.User.NumberOfDonatedBooks--;
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

        ///////////////////////////////////////////////////////////////////////////////////////////////////
        public UsedBookDtoGet GetUsedBook(int id, string[] include = null)
        {
            string[] includeProperties = { "Author" };

            Book bookDB = bookRepository.GetUsedBook(id, includeProperties);
            UsedBookDtoGet bookDTO = mapper.Map<UsedBookDtoGet>(bookDB);
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

        //////////////////////////////////////////////////////////////////////////////////////////////////
        public PaginatedList<UsedBookDtoGet> GetPaginatedUsedBooks(int page, int pageSize, string[] include = null)
        {
            string[] includeProperties = { "Author" };
            PaginatedList<Book> paginatedList = bookRepository.GetPaginatedUsedBooks(page, pageSize, includeProperties);
            IEnumerable<UsedBookDtoGet> booksDTOs = mapper.Map<IEnumerable<UsedBookDtoGet>>(paginatedList.Items);
            PaginatedList<UsedBookDtoGet> paginatedListDTO = new()
            {
                TotalPages = paginatedList.TotalPages,
                TotalItems = paginatedList.TotalItems,
                CurrentPage = paginatedList.CurrentPage,
                Items = booksDTOs
            };
            return paginatedListDTO;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////

        public void InsertUsedBook(UsedBookDtoInsert bookDto)
        {
            Book bookDB = mapper.Map<Book>(bookDto);
            bookDB.IsAvailableForDonation = true;
            var userId = GetCurrentUserId();
            var userName = GetCurrentUserName();
            bookDB.UserId = userId;
            var user = bookRepository.GetUserById(userId);
            bookDB.DonorName = userName;
            bookRepository.Insert(bookDB);
            bookDB.User.NumberOfDonatedBooks++;
        }

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
        public List<UsedBookDtoGet> SearchUsedBook(string SearchBookName)
        {
            List<Book> booksDB = bookRepository.SearchUsedBook(SearchBookName);
            List<UsedBookDtoGet> booksDTO = mapper.Map<List<UsedBookDtoGet>>(booksDB);
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
        ///////////////////////////////////////////////////////////////

        public void UpdateUsedBook(int id, UsedBookDtoInsert bookDto)
        {
            Book bookDB = bookRepository.GetUsedBook(id);
            if (bookDB != null)
            {
                mapper.Map(bookDto, bookDB);
                bookRepository.Update(bookDB);
            }
            else
            {
                throw new KeyNotFoundException($"This UsedBook with Id :{id} was not found.");
            }



        }
        ////////////////////////////////////////

    }
}

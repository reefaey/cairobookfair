﻿using Cairo_book_fair.DTOs;

namespace Cairo_book_fair.Services
{
    public interface IBookService
    {

        public PaginatedList<BookWithDetails> GetPaginatedBooks(int page, int pageSize, string[] include = null);
        public PaginatedList<UsedBookDtoGet> GetPaginatedUsedBooks(int page, int pageSize, string[] include = null);
        BookWithDetails Get(int id, string[] include = null);
        UsedBookDtoGet GetUsedBook(int id, string[] include = null);
        void Insert(BookDTO item);
        void InsertUsedBook(UsedBookDtoInsert item);
        void Update(int id, BookDTO item);
        void UpdateUsedBook(int id, UsedBookDtoInsert item);
        void Delete(int id);
        void DeleteUsedBook(int id);
        public void Save();
        public List<BookWithDetails> Search(string SearchBookName);
        public List<ReviewDTO> GetBooksReviews(int bookid);
        public List<UsedBookDtoGet> SearchUsedBook(string SearchBookName);

    }
}

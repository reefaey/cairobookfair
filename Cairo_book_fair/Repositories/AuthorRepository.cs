﻿using Cairo_book_fair.DBContext;
using Cairo_book_fair.Models;
using Microsoft.EntityFrameworkCore;

namespace Cairo_book_fair.Repositories
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        protected readonly Context _context;

        public AuthorRepository(Context _context) : base(_context)
        {

        }

        public List<Author> GetSearchResult(string term)
        {
            var result = _context.Set<Author>()
                .Include(b => b.Books)
                .Where(a => a.Name.Contains(term)).ToList();
            //|| a.Books.Name.Conatins(term)

            return result;
        }

    }
}


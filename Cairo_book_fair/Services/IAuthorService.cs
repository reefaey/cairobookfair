using Cairo_book_fair.DTOs;
using Cairo_book_fair.Models;
using Cairo_book_fair.Repositories;

namespace Cairo_book_fair.Services
{
    public interface IAuthorService 
    {

        public List<AuthorDTO> GetPaginatedAuthor(int page, int pageSize);

        public Author MappingFromAuthorDtoToAuthor(AuthorDTO authorDto, Author author = null);
        public List<AuthorDTO> GetAllDTO(string include = null);

        public AuthorDTO Get(int id);

        public Author GetById(int id);


        public void Delete(int id);

        public void Update(int id, AuthorDTO author);

        public void Insert(Author item);
        public void Save();

        public List<Author> Get(Func<Author, bool> where);

        public List<Author> GetAll(string include = null);

    }
}

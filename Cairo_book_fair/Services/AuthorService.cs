using Cairo_book_fair.DBContext;
using Cairo_book_fair.DTOs;
using Cairo_book_fair.Models;
using Cairo_book_fair.Repositories;

namespace Cairo_book_fair.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            this.authorRepository = authorRepository;
        }

        //***************************************************


        public Author MappingFromAuthorDtoToAuthor(AuthorDTO authorDto, Author? author)
        {
            if(author == null)
            {
                author = new();
            }
            author.Id = 0;
            author.Name = authorDto.Name;
            author.Description = authorDto.Description;
            author.Image = authorDto.Image;
            author.NumberOfBooks = authorDto.NumberOfBooks;
            author.Books = new List<Book>();

            return author;
        }


        public void Delete(int id)
        {
            Author item = authorRepository.Get(id);
            authorRepository.Delete(item);
            authorRepository.Save();
        }

        public List<AuthorDTO> GetAllDTO(string include = null)
        {
            var authors = authorRepository.GetAll(include)
                .Select(author => new AuthorDTO
                {
                    Name = author.Name,
                    Image = author.Image,
                    Description = author.Description,
                    NumberOfBooks = author.NumberOfBooks
                })
                .ToList();

            return authors;
        }
        public List<Author> GetAll(string include = null)
        {
            return authorRepository.GetAll(include);
        }

        public AuthorDTO Get(int id)
        {
            Author author = authorRepository.Get(id);
            AuthorDTO authorDTO = new();

            authorDTO.Name = author.Name;
            authorDTO.Description = author.Description;
            authorDTO.Image = author.Image;
            authorDTO.NumberOfBooks = author.NumberOfBooks;

            return authorDTO;
        }

        public Author GetById(int id)
        {
            return authorRepository.Get(id);
        }

        public List<Author> Get(Func<Author, bool> where)
        {
            return authorRepository.Get(where);
        }

        public void Insert(Author item)
        {
            authorRepository.Insert(item);
            authorRepository.Save();
        }

        public void Update(int id, AuthorDTO author)
        {
            Author item = authorRepository.Get(id);
            item.Name = author.Name;
            item.Description = author.Description;
            item.Image = author.Image;
            item.NumberOfBooks = author.NumberOfBooks;

            authorRepository.Update(item);

        }

        public void Save()
        {
            authorRepository.Save();
        }
















        #region Commented
        //public List<Author> GetAll(string[]? includes = null)
        //{
        //    return authorRepository.GetAll(include);  // the base function handles the null with if condition
        //}

        //public Author Get(int id)
        //{
        //    return authorRepository.Get(id);
        //}

        //public List<Author> Get(Func<Order, bool> where)
        //{
        //    return authorRepository.Get(where);
        //}

        //public void Insert(Order order)
        //{
        //    ///TODO : possible bug place (NULL Refernce Exception)
        //    /// question : do I have to create an instance ? and in the service or repo ?

        //    #region commented mapping the refernce values in a new instance
        //    // mapping the refernce values in a new instance
        //    //Order newOrder = new Order();

        //    //newOrder.Id = order.Id;
        //    //newOrder.User = order.User;
        //    //newOrder.OrderDate = order.OrderDate;
        //    //newOrder.OrderItems = order.OrderItems;

        //    //newOrder.ApplicationUserId = order.ApplicationUserId;
        //    //newOrder.User = order.User;

        //    //newOrder.ShipmentId = order.ShipmentId;
        //    //newOrder.Shipment = order.Shipment; 
        //    #endregion

        //    authorRepository.Insert(order);
        //    authorRepository.Save();
        //}

        //public void Update(Order updatedOrder)
        //{
        //    ///TODO : possible bug place (NULL Refernce Exception)
        //    Order order = Get(updatedOrder.Id);

        //    #region commented mapping 
        //    //order.User = updatedOrder.User;
        //    //order.OrderDate = updatedOrder.OrderDate;
        //    //order.OrderItems = updatedOrder.OrderItems;

        //    //order.ApplicationUserId = updatedOrder.ApplicationUserId;
        //    //order.User = updatedOrder.User;

        //    //order.ShipmentId = updatedOrder.ShipmentId;
        //    //order.Shipment = updatedOrder.Shipment; 
        //    #endregion

        //    authorRepository.Update(author);
        //}

        //public void Delete(Author author)
        //{
        //    authorRepository.Delete(author);
        //}

        //public void Save()
        //{
        //    authorRepository.Save();
        //} 
        #endregion
    }
}

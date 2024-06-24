using Cairo_book_fair.DTOs;
using Cairo_book_fair.Models;
using Cairo_book_fair.Repositories;

namespace Cairo_book_fair.Services
{
    public class Service<T> : IService<T> where T : class
    {
       
        private readonly IRepository<T> _repository;
        public Service(IRepository<T> repository)
        {
            _repository = repository;
        }
        //***************************************************

        public void Delete(T item)
        {
            _repository.Delete(item);
        }

        public List<T> GetAll(string include = null)
        {
            return _repository.GetAll(include);
        }

        public T Get(int id)
        {
            return _repository.Get(id);
        }

        public List<T> Get(Func<T, bool> where)
        {
            return _repository.Get(where);
        }

        public void Insert(T item)
        {
            _repository.Insert(item);
        }

        public void Update(T item)
        {
            _repository.Update(item);
        }

        public void Save()
        {
            _repository.Save();
        }
    }
}

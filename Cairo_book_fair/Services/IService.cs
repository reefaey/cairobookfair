using Cairo_book_fair.DTOs;
using Cairo_book_fair.Repositories;

namespace Cairo_book_fair.Services
{
    public interface IService<T>
    {
        public void Delete(T item);

        public List<T> GetAll(string include = null);

        public T Get(int id);

        public List<T> Get(Func<T, bool> where);
        public void Insert(T item);

        public void Update(T item);

        public void Save();
    }
}

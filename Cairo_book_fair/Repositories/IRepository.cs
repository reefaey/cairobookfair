namespace Cairo_book_fair.Repositories
{
    public interface IRepository<T>
    {
        List<T> GetAll(string[] includes = null);

        T Get(int id);

        List<T> Get(Func<T, bool> where);

        void Insert(T item);

        void Update(T item);

        void Delete(T item);

        void Save();
    }
}

namespace Cairo_book_fair.Repositories
{
    public interface IRepository<T>
    {
        //public List<T> GetAll(string[] include = null);
        public List<T> GetAll(string include = null);


        //T Get(int id, string[] include = null);
        public T Get(int Id);

        List<T> Get(Func<T, bool> where);

        void Insert(T item);

        void Update(T item);

        void Delete(T item);

        void Save();
    }
}

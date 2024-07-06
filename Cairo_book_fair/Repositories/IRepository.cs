namespace Cairo_book_fair.Repositories
{
    public interface IRepository<T>
    {
        //public List<T> GetAll(string[] include = null);
        public List<T> GetAll(string include = null);


        //T Get(int id, string[] include = null);
        public T Get(int Id);

        public List<T> Get(Func<T, bool> where);

        public void Insert(T item);

        public void Update(T item);

        public void Delete(T item);

        public void Save();
    }
}

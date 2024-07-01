namespace Cairo_book_fair.Services
{
    public interface IBookCartService
    {
        public void AddItem(string userId, int bookId);

        public void RemoveItem(string userId, int bookId);

        public void Save();


    }
}

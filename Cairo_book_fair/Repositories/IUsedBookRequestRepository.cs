using Cairo_book_fair.Models;

namespace Cairo_book_fair.Repositories
{
    public interface IUsedBookRequestRepository : IRepository<UsedBookRequest>
    {
        public List<UsedBookRequest>? GetAllUserRequest(string userID);

    }
}

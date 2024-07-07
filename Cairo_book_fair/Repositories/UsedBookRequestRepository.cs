using Cairo_book_fair.DBContext;
using Cairo_book_fair.Models;

namespace Cairo_book_fair.Repositories
{
    public class UsedBookRequestRepository : Repository<UsedBookRequest>
    {
        public UsedBookRequestRepository(Context _context) : base(_context)
        {
        }

        public List<UsedBookRequest>? GetAllUserRequest(string userID)
        {
            List<UsedBookRequest>? usedBookRequests = Context.Set<UsedBookRequest>()
                .Where(req => req.UserId == userID).ToList();

            if(usedBookRequests == null)
            {
                return null;
            }

            return usedBookRequests;
        }
    }
}

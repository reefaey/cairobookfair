using Cairo_book_fair.DTOs;
using Cairo_book_fair.Models;
using Cairo_book_fair.Repositories;

namespace Cairo_book_fair.Services
{
    public interface IUsedBookRequestService : IService<UsedBookRequest>
    {
        public void SendRequest(string userId, UsedBookDtoInsert usedBookDtoInsert);
    }
}

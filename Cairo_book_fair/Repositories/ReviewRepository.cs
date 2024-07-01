using Cairo_book_fair.DBContext;
using Cairo_book_fair.Models;
using Google;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cairo_book_fair.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly Context context;

        public ReviewRepository(Context context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Review>> GetAllReviews()
        {
            return await context.Reviews.Include(r => r.Book).Include(r => r.User).ToListAsync();
        }

        /*public async Task<Review> GetReviewById(int id)
        {
            return await context.Reviews.Include(r => r.Book).Include(r => r.User)
                                         .FirstOrDefaultAsync(r => r.Id == id);
        }*/
        public async Task<Review> GetReviewById(int id)
        {
            var review = await context.Reviews.Include(r => r.Book).Include(r => r.User)
                                             .FirstOrDefaultAsync(r => r.Id == id);
            if (review == null)
            {
                throw new KeyNotFoundException($"Review with id {id} not found.");
            }
            return review;
        }

        public async Task<Review> AddReview(Review review)
        {
            context.Reviews.Add(review);
            await context.SaveChangesAsync();
            return review;
        }

        public async Task<Review> UpdateReview(Review review)
        {
            context.Entry(review).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return review;
        }

        public async Task<Review> DeleteReview(int id)
        {
            var review = await context.Reviews.FindAsync(id);
            if (review != null)
            {
                context.Reviews.Remove(review);
                await context.SaveChangesAsync();
            }
            return review;
        }
    }
}

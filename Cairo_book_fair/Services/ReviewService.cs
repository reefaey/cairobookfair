using Cairo_book_fair.Models;
using Cairo_book_fair.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cairo_book_fair.Services
{
    public class ReviewService : IReviewService 
    {
        private readonly IReviewRepository _reviewRepository;

        public ReviewService(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public async Task<IEnumerable<Review>> GetAllReviews()
        {
            return await _reviewRepository.GetAllReviews();
        }

        public async Task<Review> GetReviewById(int id)
        {
            return await _reviewRepository.GetReviewById(id);
        }

        public async Task<Review> AddReview(Review review)
        {
            return await _reviewRepository.AddReview(review);
        }

        public async Task<Review> UpdateReview(Review review)
        {
            return await _reviewRepository.UpdateReview(review);
        }

        public async Task<Review> DeleteReview(int id)
        {
            return await _reviewRepository.DeleteReview(id);
        }
    }
}

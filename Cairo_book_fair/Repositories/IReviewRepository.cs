﻿using Cairo_book_fair.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cairo_book_fair.Repositories
{
    public interface IReviewRepository
    {
        Task<IEnumerable<Review>> GetAllReviews();
        Task<Review> GetReviewById(int id);
        Task<Review> AddReview(Review review);
        Task<Review> UpdateReview(Review review);
        Task<Review> DeleteReview(int id);
    }
}
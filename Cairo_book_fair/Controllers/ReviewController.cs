using Microsoft.AspNetCore.Mvc;
using Cairo_book_fair.DTOs;
using Cairo_book_fair.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cairo_book_fair.Models;

namespace Cairo_book_fair.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewsController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReviewDTO>>> GetReviews()
        {
            var reviews = await _reviewService.GetAllReviews();
            var reviewDTOs = reviews.Select(review => new ReviewDTO
            {
                Id = review.Id,
                Date = review.Date,
                Comment = review.Comment,
                BookId = review.BookId,
                UserId = review.UserId
            });
            return Ok(reviewDTOs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReviewDTO>> GetReview(int id)
        {
            var review = await _reviewService.GetReviewById(id);
            if (review == null)
            {
                return NotFound();
            }

            var reviewDTO = new ReviewDTO
            {
                Id = review.Id,
                Date = review.Date,
                Comment = review.Comment,
                BookId = review.BookId,
                UserId = review.UserId
            };

            return Ok(reviewDTO);
        }

        [HttpPost]
        public async Task<ActionResult<ReviewDTO>> PostReview(ReviewDTO reviewDTO)
        {
            var review = new Review
            {
                Date = reviewDTO.Date,
                Comment = reviewDTO.Comment,
                BookId = reviewDTO.BookId,
                UserId = reviewDTO.UserId
            };

            var createdReview = await _reviewService.AddReview(review);

            reviewDTO.Id = createdReview.Id;

            return CreatedAtAction(nameof(GetReview), new { id = createdReview.Id }, reviewDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutReview(int id, ReviewDTO reviewDTO)
        {
            if (id != reviewDTO.Id)
            {
                return BadRequest();
            }

            var review = new Review
            {
                Id = reviewDTO.Id,
                Date = reviewDTO.Date,
                Comment = reviewDTO.Comment,
                BookId = reviewDTO.BookId,
                UserId = reviewDTO.UserId
            };

            try
            {
                await _reviewService.UpdateReview(review);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }
         
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReview(int id)
        {
            var review = await _reviewService.GetReviewById(id);
            if (review == null)
            {
                return NotFound();
            }

            await _reviewService.DeleteReview(id);

            return NoContent();
        }
    }
}

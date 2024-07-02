using Microsoft.AspNetCore.Mvc;
using Cairo_book_fair.Models;
using Cairo_book_fair.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Cairo_book_fair.DBContext;

namespace Cairo_book_fair.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewService reviewService;

        public ReviewsController(IReviewService reviewService)
        {
            reviewService = reviewService;
        }

        // GET: api/Reviews
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Review>>> GetReviews()
        {
            return Ok(await reviewService.GetAllReviews());
        }

        // GET: api/Reviews/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Review>> GetReview(int id)
        {
            var review = await reviewService.GetReviewById(id);

            if (review == null)
            {
                return NotFound();
            }

            return review;
        }

        // POST: api/Reviews
        [HttpPost]
        public async Task<ActionResult<Review>> PostReview(Review review)
        {
            await reviewService.AddReview(review);
            return CreatedAtAction("GetReview", new { id = review.Id }, review);
        }

        // PUT: api/Reviews/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReview(int id, Review review)
        {
            if (id != review.Id)
            {
                return BadRequest();
            }

            try
            {
                await reviewService.UpdateReview(review);
            }
            catch (DbUpdateConcurrencyException)
            {
                if ((await reviewService.GetReviewById(id)) == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Reviews/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReview(int id)
        {
            var review = await reviewService.GetReviewById(id);
            if (review == null)
            {
                return NotFound();
            }

            await reviewService.DeleteReview(id);
            return NoContent();
        }


        /* public async Task<Review> DeleteReview(int id)
         {
             var review = await context.Reviews.FindAsync(id);
             if (review == null)
             {
                 throw new KeyNotFoundException($"Review with id {id} not found.");
             }
             context.Reviews.Remove(review);
             await context.SaveChangesAsync();
             return review;
         }*/
    }
}
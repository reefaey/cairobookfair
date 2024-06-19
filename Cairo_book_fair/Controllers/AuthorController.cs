using Cairo_book_fair.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cairo_book_fair.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<AuthorDTO>> GetAuthors()
        {
            var posts = _postRepository.GetAll()
                .Select(post => new AuthorDTO
                {
                    Content = post.Content,
                    PostTime = post.PostTime,
                    PostImage = post.PostImage,
                    UserId = post.UserId
                })
                .ToList();

            return Ok(posts);
        }
    }
}

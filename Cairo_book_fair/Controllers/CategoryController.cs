using Cairo_book_fair.Models;
using Cairo_book_fair.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Cairo_book_fair.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        [HttpGet]
        public IActionResult GetAll(string[] includes = null)
        {
            List<Category> categories = categoryRepository.GetAll();
            return Ok(categories);
        }

        [HttpGet("All")]
        public IActionResult Get(Func<Category, bool> where)
        {
            List<Category> categories = categoryRepository.Get(where);
            return Ok(categories);

        }


        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            Category category = categoryRepository.Get(id);
            if (category != null)
            {
                return Ok(category);
            }
            return BadRequest();
        }

        [HttpPost]
        public IActionResult Insert(Category category)
        {
            if (ModelState.IsValid == true)
            {
                categoryRepository.Insert(category);
                categoryRepository.Save();
                return CreatedAtAction("Get", new { id = category.Id }, category);
            }
            return BadRequest(ModelState);
        }
        [HttpPut]
        public IActionResult Update(Category category)
        {
            if (ModelState.IsValid == true)
            {
                categoryRepository.Update(category);
                categoryRepository.Save();
                return NoContent();
            }
            return BadRequest(ModelState);
        }
        [HttpDelete]
        public IActionResult Delete(Category category)
        {
            categoryRepository.Delete(category);
            return NoContent();
        }
    }
}

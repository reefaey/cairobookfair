using Cairo_book_fair.Models;
using Cairo_book_fair.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cairo_book_fair.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult GetAll(string[] includes = null)
        {
            List<Category> categories = categoryService.GetAll();
            return Ok(categories);
        }

        [HttpGet("All")]
        public IActionResult Get(Func<Category, bool> where)
        {
            List<Category> categories = categoryService.Get(where);
            return Ok(categories);

        }


        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            Category category = categoryService.Get(id);
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
                categoryService.Insert(category);
                categoryService.Save();
                return CreatedAtAction("Get", new { id = category.Id }, category);
            }
            return BadRequest(ModelState);
        }
        [HttpPut]
        public IActionResult Update(Category category)
        {
            if (ModelState.IsValid == true)
            {
                categoryService.Update(category);
                categoryService.Save();
                return NoContent();
            }
            return BadRequest(ModelState);
        }
        [HttpDelete]
        public IActionResult Delete(Category category)
        {
            categoryService.Delete(category);
            return NoContent();
        }
    }
}

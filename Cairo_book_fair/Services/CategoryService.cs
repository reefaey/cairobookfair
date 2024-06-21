using Cairo_book_fair.Models;
using Cairo_book_fair.Repositories;

namespace Cairo_book_fair.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
        public void Delete(Category item)
        {
            categoryRepository.Delete(item);
        }

        public Category Get(int id)
        {
            return categoryRepository.Get(id);
        }

        public List<Category> Get(Func<Category, bool> where)
        {
            return categoryRepository.Get(where).ToList();
        }

        public List<Category> GetAll(string include = null)
        {
            return categoryRepository.GetAll(include);
        }

        public void Insert(Category item)
        {
            categoryRepository.Insert(item);
        }

        public void Save()
        {
            categoryRepository.Save();
        }

        public void Update(Category item)
        {
            categoryRepository.Update(item);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositories;
using Repositories.Entity;
using Services.DTO;

namespace Services
{
    public class CategoryService
    {
        private readonly CategoryRepository _categoryRepository;

        public CategoryService(CategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Category> CreateCategoryAsync(CreateCategoryRequest createCategoryRequest)
        {
            var category = new Category
            {
                Name = createCategoryRequest.Name,
                Description = createCategoryRequest.Description
            };
            await _categoryRepository.CreateAsync(category);
            return category;
        }

        public async Task DeleteCategoryAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null)
            {
                throw new KeyNotFoundException($"Category with ID {id} not found.");
            }
            await _categoryRepository.RemoveAsync(category);
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await _categoryRepository.GetAllAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null)
            {
                throw new KeyNotFoundException($"Category with ID {id} not found.");
            }
            return category;
        }

        public async Task<Category> UpdateCategoryAsync(int id, CreateCategoryRequest updateCategoryRequest)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null)
            {
                throw new KeyNotFoundException($"Category with ID {id} not found.");
            }
            category.Name = updateCategoryRequest.Name;
            category.Description = updateCategoryRequest.Description;
            await _categoryRepository.UpdateAsync(category);
            return category;
        }

        public async Task<Category> GetCategoryByNameAsync(string name)
        {
            var category = await _categoryRepository.GetByNameAsync(name); // Fix: Ensure GetByNameAsync returns a Task<Category>
            if (category == null)
            {
                throw new KeyNotFoundException($"Category with name '{name}' not found.");
            }
            return category;
        }
    }
}

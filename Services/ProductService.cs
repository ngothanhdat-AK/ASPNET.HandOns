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
    public class ProductService
    {
        private readonly ProductRepository _productRepository;
        private readonly CategoryRepository _categoryRepository;

        public ProductService(ProductRepository productRepository, CategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
        }
        public async Task<Product> CreateProductAsync(CreateProductRequest createProductRequest)
        {
            var category = await _categoryRepository.GetByNameAsync(createProductRequest.CategoryName);
            if (category == null)
            {
                throw new KeyNotFoundException($"Category with name {createProductRequest.CategoryName} not found.");
            }
            var product = new Product
            {
                Name = createProductRequest.Name,
                Description = createProductRequest.Description,
                CategoryId = category.CategoryId,
                CreatedAt = DateTime.Now
            };
            await _productRepository.CreateAsync(product);
            return product;
        }

        public async Task DeleteProductAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            await _productRepository.RemoveAsync(product);
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _productRepository.GetAllAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                throw new KeyNotFoundException($"Product with ID {id} not found.");
            }
            return product;
        }

        public async Task<Product> UpdateProductAsync(int id, CreateProductRequest updateProductRequest)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                throw new KeyNotFoundException($"Product with ID {id} not found.");
            }
            product.Name = updateProductRequest.Name;
            product.Description = updateProductRequest.Description;
            await _productRepository.UpdateAsync(product);
            return product;
        }
        public async Task<Product?> GetProductWithCategoryAsync(int id)
        {
            return await _productRepository.GetByIdWithCategoryAsync(id);
        }
        public async Task<ProductResponse.ProductResponseDto?> GetProductResponseByIdAsync(int id)
        {
            var product = await GetProductWithCategoryAsync(id);
            if (product == null) return null;
            return ProductMapper.MapToProductResponseDto(product);
        }

        public async Task<IEnumerable<ProductResponse.ProductResponseDto>> GetAllProductResponsesAsync()
        {
            var products = await GetAllProductsAsync();
            return products.Select(ProductMapper.MapToProductResponseDto);
        }
    } 
}

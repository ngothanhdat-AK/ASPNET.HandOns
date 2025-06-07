using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositories.Entity;
using Services.DTO;

namespace Services
{
    public static class ProductMapper
    {
        public static ProductResponse.ProductResponseDto MapToProductResponseDto(Product product)
        {
            return new ProductResponse.ProductResponseDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                CreatedAt = product.CreatedAt,
                CategoryId = product.CategoryId,
                Category = product.Category == null ? null : new ProductResponse.CategoryDto
                {
                    CategoryId = product.Category.CategoryId,
                    Name = product.Category.Name,
                    Description = product.Category.Description
                }
            };
        }
    }
}

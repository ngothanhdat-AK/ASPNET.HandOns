using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.DTO;

namespace ASPNET.HandOns.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productService.GetAllProductsAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var productDto = await _productService.GetProductResponseByIdAsync(id);
            if (productDto == null) return NotFound();
            return Ok(productDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductRequest request)
        {
            var product = await _productService.CreateProductAsync(request);
            // Lấy lại product kèm category để map sang DTO
            var productWithCategory = await _productService.GetProductWithCategoryAsync(product.Id);
            var response = ProductMapper.MapToProductResponseDto(productWithCategory);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _productService.DeleteProductAsync(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] CreateProductRequest updateProductRequest)
        {
            var updatedProduct = await _productService.UpdateProductAsync(id, updateProductRequest);
            return Ok(updatedProduct);
        }

    }
}

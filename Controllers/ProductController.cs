using MahalliyMarket.DTOs;
using MahalliyMarket.DTOs.ProductDTOs;
using MahalliyMarket.Models;
using MahalliyMarket.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MahalliyMarket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<Product>>>> GetAll()
        {
            var result = await _productService.GetAllProductsAsync();
            return StatusCode(result.GetHashCode(), result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<Product>>> GetById(int id)
        {
            var result = await _productService.GetProductByIdAsync(id);
            return StatusCode(result.status_code, result);
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse<Product>>> Create([FromBody] ProductCreateDTO productDTO)
        {
            var result = await _productService.CreateProductAsync(productDTO);
            return StatusCode(result.status_code, result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResponse<Product>>> Update(int id, [FromBody] Product product)
        {
            var result = await _productService.UpdateProductAsync(id, product);
            return StatusCode(result.status_code, result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse<bool>>> Delete(int id)
        {
            var result = await _productService.DeleteProductAsync(id);
            return StatusCode(result.status_code, result);
        }
    }
}

using MahalliyMarket.Models;
using MahalliyMarket.DTOs;
using MahalliyMarket.Services.Interfaces;
using MahalliyMarket.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using MahalliyMarket.DTOs.ProductDTOs;

namespace MahalliyMarket.Services
{
    public class ProductService : IProductService
    {
        private readonly MahalliyDBContext _context;
        
        public ProductService(MahalliyDBContext context)
        {
            _context = context;
        }

        public async Task<ApiResponse<Product>> GetProductByIdAsync(int id)
        {
            var product = await _context.products.FindAsync(id);
            if (product == null)
                return new ApiResponse<Product>(404, "Product not found");
            return new ApiResponse<Product>(200, product);
        }

        public async Task<ApiResponse<IEnumerable<Product>>> GetAllProductsAsync()
        {
            var products = await _context.products.ToListAsync();
            return new ApiResponse<IEnumerable<Product>>(200, products);
        }

        public async Task<ApiResponse<Product>> CreateProductAsync(ProductCreateDTO productDTO)
        {
            var domain = new Product
            {
                user_id = productDTO.user_id,
                name = productDTO.product_name,
                description = productDTO.product_desc,
                price = productDTO.product_price,
                quantity = productDTO.product_quantity,
                discount_percentage = productDTO.discount_percentage,
                category_id = productDTO.category_id
            };

            _context.products.Add(domain);
            await _context.SaveChangesAsync();

            return new ApiResponse<Product>(201, domain);
        }

        public async Task<ApiResponse<Product>> UpdateProductAsync(int id, Product product)
        {
            var existing = await _context.products.FindAsync(id);
            if (existing == null)
                return new ApiResponse<Product>(404, "Product not found");

            // Update properties (for brevity, only a few shown)
            existing.name = product.name;
            existing.description = product.description;
            existing.price = product.price;
            existing.quantity = product.quantity;
            existing.discount_percentage = product.discount_percentage;
            existing.category_id = product.category_id;
            // ... update other properties as needed

            await _context.SaveChangesAsync();
            return new ApiResponse<Product>(200, existing);
        }

        public async Task<ApiResponse<bool>> DeleteProductAsync(int id)
        {
            var product = await _context.products.FindAsync(id);
            if (product == null)
                return new ApiResponse<bool>(404, "Product not found");
            _context.products.Remove(product);
            await _context.SaveChangesAsync();
            return new ApiResponse<bool>(200, true);
        }
    }
}

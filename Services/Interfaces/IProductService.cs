using MahalliyMarket.Models;
using MahalliyMarket.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;
using MahalliyMarket.DTOs.ProductDTOs;

namespace MahalliyMarket.Services.Interfaces
{
    public interface IProductService
    {
        Task<ApiResponse<Product>> GetProductByIdAsync(int id);
        
        Task<ApiResponse<IEnumerable<Product>>> GetAllProductsAsync();
        
        Task<ApiResponse<Product>> CreateProductAsync(ProductCreateDTO productDTO);
        
        Task<ApiResponse<Product>> UpdateProductAsync(int id, Product product);
        
        Task<ApiResponse<bool>> DeleteProductAsync(int id);
    }
}

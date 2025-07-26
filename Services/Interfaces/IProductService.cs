using MahalliyMarket.DTOs;
using MahalliyMarket.DTOs.ProductDTOs;
using MahalliyMarket.Models;

namespace MahalliyMarket.Services.Interfaces
{
    public interface IProductService
    {
        Task<ApiResponse<ConfirmationResponse>> CreateProductAsync(ProductCreateUserDTO productDTO);

        Task<ApiResponse<Product>> GetProductByIdAsync(int id);

        Task<ApiResponse<IEnumerable<Product>>> GetAllProductsAsync();

        Task<ApiResponse<IEnumerable<ProductResponseUserDTO>>> GetAllProductByUserIdAsync(int userId);

        Task<ApiResponse<Product>> UpdateProductAsync(int id, Product product);

        Task<ApiResponse<bool>> DeleteProductAsync(int id);
    }
}

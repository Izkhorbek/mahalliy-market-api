using MahalliyMarket.DTOs;
using MahalliyMarket.DTOs.ProductDTOs;

namespace MahalliyMarket.Services.Interfaces
{
    public interface IProductAdminService
    {
        Task<ApiResponse<ConfirmationResponse>> CreateProductAsync(ProductCreateUserDTO productDTO);
    }
}

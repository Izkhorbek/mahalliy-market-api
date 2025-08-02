using MahalliyMarket.DTOs;
using MahalliyMarket.DTOs.ProductDTOs;

namespace MahalliyMarket.Services.Interfaces
{
    public interface IProductUserService
    {
        Task<ApiResponse<ProductUserDTO>> GetProductByIdAsync(int productId);

        Task<ApiResponse<IEnumerable<AllProductsUserDTO>>> GetAllProductsAsync();

        Task<ApiResponse<IEnumerable<AllProductsUserDTO>>> GetAllProductByUserIdAsync(int userId);

        //Product Videos
        Task<ApiResponse<IEnumerable<ProductVideoUserDTO>>> GetProductVideoByIdAsync(int productId);


        // Feedback berishdan oldin mahsulot olganmi tekshirish kerak
        //Feedbacks
        Task<ApiResponse<ConfirmationResponse>> CreateProductFeedbackAsync(FeedbackCreateDTO feedbackDTO);
        Task<ApiResponse<ConfirmationResponse>> DeleteProductFeedbackAsync(int customer_id, int product_id, int feedback_id);
        Task<ApiResponse<IEnumerable<ProductFeedbackUserDTO>>> GetProductFeedbacksByIdAsync(int productId);

        // Hot Product
        Task<ApiResponse<IEnumerable<AllProductsUserDTO>>> GetAllHotProductsAsync();
        Task<ApiResponse<AllProductsUserDTO>> GetHotProductByIdAsync(int productId);


        //New Products
        Task<ApiResponse<AllProductsUserDTO>> GetAllNewProductsAsync();
        Task<ApiResponse<AllProductsUserDTO>> GetNewProductByIdAsync(int productId);


        //Big sale Products
        Task<ApiResponse<AllProductsUserDTO>> GetAllBigSaleProductsAsync();
        Task<ApiResponse<AllProductsUserDTO>> GetBigSaleProductByIdAsync(int productId);
    }
}

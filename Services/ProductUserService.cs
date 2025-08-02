using AutoMapper;
using MahalliyMarket.Data;
using MahalliyMarket.DTOs;
using MahalliyMarket.DTOs.ProductDTOs;
using MahalliyMarket.DTOs.UserDTOs;
using MahalliyMarket.Models;
using MahalliyMarket.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MahalliyMarket.Services
{
    public class ProductUserService : IProductUserService
    {
        private readonly MahalliyDBContext _context;

        private readonly IMapper _mapper;

        public ProductUserService(MahalliyDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ApiResponse<ProductUserDTO>> GetProductByIdAsync(int id)
        {
            var productEntity = await _context
                .products.Where(p => p.id == id)
                .Include(p => p.category)
                .Include(p => p.seller)
                .Include(p => p.primary_image)
                .Include(p => p.images)
                .Include(p => p.feedbacks)
                .Include(p => p.sales)
                .Include(p => p.delivery_options)
                .FirstOrDefaultAsync();

            if ( productEntity == null )
                return new ApiResponse<ProductUserDTO>(404, "Product not found");

            var productDomain = new ProductUserDTO
            {
                product_id = productEntity.id,
                name = productEntity.name,
                desc = productEntity.description,
                price = productEntity.price,
                quantity = productEntity.quantity,
                tags = productEntity.tags,
                dis_percent = productEntity.discount_percentage,

                category = productEntity.category != null ? productEntity.category.category_name : "unknown",

                quantity_sold = productEntity.quantity,

                primary_image = productEntity.primary_image != null ? _mapper.Map<ProductImageUserDTO>(productEntity.primary_image) : null,

                // Seller (User) DTO mapping
                seller = productEntity.seller != null ? _mapper.Map<UserResponseDTO>(productEntity.seller) : null,

                //Images
                images = _mapper.Map<List<ProductImageUserDTO>>(productEntity.images),

                // Videos
                videos = _mapper.Map<List<ProductVideoUserDTO>>(productEntity.videos),

                // Feedbacks
                feedbacks = _mapper.Map<List<ProductFeedbackUserDTO>>(productEntity.feedbacks),

                // Sales
                sales = _mapper.Map<List<ProductSalesUserDTO>>(productEntity.sales),

                // Delivery method
                delivery_options = _mapper.Map<List<DeliveryMethodUserDTO>>(productEntity.delivery_options)
            };

            return new ApiResponse<ProductUserDTO>(200, productDomain);
        }

        public async Task<ApiResponse<IEnumerable<AllProductsUserDTO>>> GetAllProductsAsync()
        {
            var products = await _context.products.ToListAsync();
            return new ApiResponse<IEnumerable<Product>>(200, products);
        }

        public Task<ApiResponse<IEnumerable<AllProductsUserDTO>>> GetAllProductByUserIdAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<IEnumerable<ProductVideoUserDTO>>> GetProductVideoByIdAsync(int productId)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<ConfirmationResponse>> CreateProductFeedbackAsync(FeedbackCreateDTO feedbackDTO)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<ConfirmationResponse>> DeleteProductFeedbackAsync(int customer_id, int product_id, int feedback_id)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<IEnumerable<ProductFeedbackUserDTO>>> GetProductFeedbacksByIdAsync(int productId)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<IEnumerable<AllProductsUserDTO>>> GetAllHotProductsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<AllProductsUserDTO>> GetHotProductByIdAsync(int productId)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<AllProductsUserDTO>> GetAllNewProductsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<AllProductsUserDTO>> GetNewProductByIdAsync(int productId)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<AllProductsUserDTO>> GetAllBigSaleProductsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<AllProductsUserDTO>> GetBigSaleProductByIdAsync(int productId)
        {
            throw new NotImplementedException();
        }
    }
}

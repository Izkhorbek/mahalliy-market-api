using AutoMapper;
using MahalliyMarket.Data;
using MahalliyMarket.DTOs;
using MahalliyMarket.DTOs.ProductDTOs;
using MahalliyMarket.DTOs.UserDTOs;
using MahalliyMarket.Models;
using MahalliyMarket.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace MahalliyMarket.Services
{
    public class ProductService : IProductService
    {
        private readonly MahalliyDBContext _context;

        private readonly IMapper _mapper;

        public ProductService(MahalliyDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ApiResponse<ConfirmationResponse>> CreateProductAsync(ProductCreateUserDTO productDTO)
        {
            try
            {
                var domain = new Product
                {
                    seller_id = productDTO.user_id,
                    name = productDTO.product_name,
                    description = productDTO.product_desc,
                    price = productDTO.product_price,
                    quantity = productDTO.product_quantity,
                    tags = productDTO.product_tags,
                    discount_percentage = productDTO.discount_percentage,
                    category_id = productDTO.category_id,
                    primary_image_id = productDTO.primary_image_id,
                };

                _context.products.Add(domain);
                await _context.SaveChangesAsync();

            }
            catch ( Exception ex )
            {
                return new ApiResponse<ConfirmationResponse>(HttpStatusCode.ExpectationFailed, $"Something happened. error: {ex.Message}");
            }

            return new ApiResponse<ConfirmationResponse>(HttpStatusCode.Created, new ConfirmationResponse("Product is created successfully ."));
        }

        public async Task<ApiResponse<ProductResponseUserDTO>> GetProductByIdAsync(int id)
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
                return new ApiResponse<ProductResponseUserDTO>(404, "Product not found");

            var productDomain = new ProductResponseUserDTO
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

            return new ApiResponse<ProductResponseUserDTO>(200, productDomain);
        }

        public async Task<ApiResponse<IEnumerable<Product>>> GetAllProductsAsync()
        {
            var products = await _context.products.ToListAsync();
            return new ApiResponse<IEnumerable<Product>>(200, products);
        }


        public async Task<ApiResponse<Product>> UpdateProductAsync(int id, Product product)
        {
            var existing = await _context.products.FindAsync(id);
            if ( existing == null )
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
            if ( product == null )
                return new ApiResponse<bool>(404, "Product not found");
            _context.products.Remove(product);
            await _context.SaveChangesAsync();
            return new ApiResponse<bool>(200, true);
        }

        public Task<ApiResponse<IEnumerable<ProductResponseUserDTO>>> GetAllProductByUserIdAsync(int userId)
        {
            throw new NotImplementedException();
        }

        Task<ApiResponse<Product>> IProductService.GetProductByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}

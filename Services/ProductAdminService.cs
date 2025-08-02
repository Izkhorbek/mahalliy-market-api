using AutoMapper;
using MahalliyMarket.Data;
using MahalliyMarket.DTOs;
using MahalliyMarket.DTOs.ProductDTOs;
using MahalliyMarket.Services.Interfaces;
using System.Net;

namespace MahalliyMarket.Services
{
    public class ProductAdminService : IProductAdminService
    {
        private readonly MahalliyDBContext _context;

        private readonly IMapper _mapper;

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

        public async Task<ApiResponse<bool>> DeleteProductAsync(int id)
        {
            var product = await _context.products.FindAsync(id);
            if ( product == null )
                return new ApiResponse<bool>(404, "Product not found");
            _context.products.Remove(product);
            await _context.SaveChangesAsync();
            return new ApiResponse<bool>(200, true);
        }
    }
}

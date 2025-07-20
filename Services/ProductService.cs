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

        public ProductService(MahalliyDBContext context)
        {
            _context = context;
        }

        public async Task<ApiResponse<ConfirmationResponse>> CreateProductAsync(ProductCreateDTO productDTO)
        {
            var domain = new Product
            {
                user_id = productDTO.user_id,
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

            return new ApiResponse<ConfirmationResponse>(HttpStatusCode.Created, new ConfirmationResponse("Product is created successfully ."));
        }


        public async Task<ApiResponse<ProductResponseDTO>> GetProductByIdAsync(int id)
        {
            var product = await _context.
                products.Where(p => p.id == id)
                .Include(p => p.category)
                .Include(p => p.user)
                .Include(p => p.primary_image)
                .Include(p => p.images)
                .Select(p => new ProductResponseDTO
                {
                    id = p.id,
                    name = p.name,
                    description = p.description,
                    price = p.price,
                    quantity = p.quantity,
                    tags = p.tags,
                    dis_percent = p.discount_percentage,
                    category = p.category != null ? p.category.category_name : "unknown",
                    primary_image_id = p.primary_image_id,
                    primary_image = p.primary_image, // or map to DTO if needed

                    // Seller (User) DTO mapping
                    seller = new UserResponseDTO
                    {
                        user_id = p.user.user_id,
                        name = p.user.name,
                        email = p.user.email
                        // Add other properties as needed
                    },

                    images = p.images.Select(img => new ProductImage
                    {
                        id = img.id,
                        url = img.url,
                        // ...map only the fields you need
                    }).ToList(),

                    // Other related collections - map if needed
                    videos = p.videos.Select(v => new ProductVideo
                    {
                        id = v.id,
                        videoUrl = v.videoUrl
                    }).ToList(),

                    feedbacks = p.feedbacks.Select(f => new ProductFeedback
                    {
                        id = f.id,
                        comment = f.comment
                    }).ToList(),

                    sales = p.sales.Select(s => new ProductSales
                    {
                        id = s.id,
                        saleDate = s.saleDate
                    }).ToList(),

                    delivery_options = p.delivery_options.Select(d => new DeliveryMethod
                    {
                        id = d.id,
                        methodName = d.methodName
                    }).ToList(),

                    order_items = p.order_items.Select(o => new OrderItem
                    {
                        id = o.id,
                        quantity = o.quantity
                    }).ToList()

                });

            if (product == null)
                return new ApiResponse<ProductResponseDTO>(404, "Product not found");

            var productDto = new ProductResponseDTO
            {
                id = product.id,
                seller = product.user != null ? new DTOs.UserDTOs.UserResponseDTO
                {
                    user_id = product.user.user_id,
                    first_name = product.user.first_name,
                    last_name = product.user.last_name,
                    middle_name = product.user.middle_name,
                    email = product.user.email,
                    phone_number = product.user.phone_number
                } : null,


                name = product.name,
                description = product.description,
                price = product.price,
                quantity = product.quantity,
                tags = product.tags,
                dis_percent = product.discount_percentage,
                category = product.category != null ? product.category.category_name : "Unknown",
                primary_image_id = product.primary_image_id,
                primary_image = product.primary_image,
                images = product.images,
                videos = product.videos,
                feedbacks = product.feedbacks,
                sales = product.sales,
                delivery_options = product.delivery_options,
                order_items = product.order_items
            };

            return new ApiResponse<ProductResponseDTO>(200, productDto);
        }

        public async Task<ApiResponse<IEnumerable<Product>>> GetAllProductsAsync()
        {
            var products = await _context.products.ToListAsync();
            return new ApiResponse<IEnumerable<Product>>(200, products);
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

        public Task<ApiResponse<IEnumerable<ProductResponseDTO>>> GetAllProductByUserIdAsync(int userId)
        {
            throw new NotImplementedException();
        }
    }
}

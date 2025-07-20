using MahalliyMarket.DTOs.UserDTOs;
using MahalliyMarket.Models;

namespace MahalliyMarket.DTOs.ProductDTOs
{
    public class ProductResponseDTO
    {
        public int id { get; set; }


        public string name { get; set; }

        public string? description { get; set; }

        public decimal price { get; set; }

        public int quantity { get; set; }

        public string? tags { get; set; }

        public int dis_percent { get; set; }

        public string category { get; set; }

        public int? primary_image_id { get; set; }


        public UserResponseDTO? seller { get; set; }
        public ProductImage? primary_image { get; set; }


        public ICollection<ProductImage> images { get; set; } = new List<ProductImage>();
        public ICollection<ProductVideo> videos { get; set; } = new List<ProductVideo>();
        public ICollection<ProductFeedback> feedbacks { get; set; } = new List<ProductFeedback>();
        public ICollection<ProductSales> sales { get; set; } = new List<ProductSales>();
        public ICollection<DeliveryMethod> delivery_options { get; set; } = new List<DeliveryMethod>();
        public ICollection<OrderItem> order_items { get; set; } = new List<OrderItem>();
    }
}

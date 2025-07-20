using MahalliyMarket.DTOs.UserDTOs;
using MahalliyMarket.Models;

namespace MahalliyMarket.DTOs.ProductDTOs
{
    public class AllProductResponseDTO
    {
        public int id { get; set; }

        public UserResponseDTO? seller { get; set; }

        public string name { get; set; }

        public string? description { get; set; }

        public decimal price { get; set; }

        public int quantity { get; set; }

        public string? tags { get; set; }

        public int discount_percentage { get; set; }

        public Category? category { get; set; }

        public int? primary_image_id { get; set; }

        public string? primary_image { get; set; }

        public ICollection<ProductImage> images { get; set; } = new List<ProductImage>();

    }
}

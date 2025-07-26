using MahalliyMarket.DTOs.UserDTOs;

namespace MahalliyMarket.DTOs.ProductDTOs
{
    public class ProductResponseUserDTO
    {
        public int product_id { get; set; }

        public string name { get; set; }

        public string? desc { get; set; }

        public decimal price { get; set; }

        public int quantity { get; set; }

        public string? tags { get; set; }

        public int dis_percent { get; set; }

        public string category { get; set; }

        public int quantity_sold { get; set; }

        public ProductImageUserDTO? primary_image { get; set; }

        public UserResponseDTO? seller { get; set; }

        public ICollection<ProductImageUserDTO> images { get; set; } = new List<ProductImageUserDTO>();
        public ICollection<ProductVideoUserDTO> videos { get; set; } = new List<ProductVideoUserDTO>();
        public ICollection<ProductFeedbackUserDTO> feedbacks { get; set; } = new List<ProductFeedbackUserDTO>();
        public ICollection<ProductSalesUserDTO> sales { get; set; } = new List<ProductSalesUserDTO>();
        public ICollection<DeliveryMethodUserDTO> delivery_options { get; set; } = new List<DeliveryMethodUserDTO>();

    }
}

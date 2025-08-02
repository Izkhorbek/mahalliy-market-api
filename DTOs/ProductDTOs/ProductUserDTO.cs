namespace MahalliyMarket.DTOs.ProductDTOs
{
    public class ProductUserDTO
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

        public ProductSellerUserDTO? seller { get; set; }

        public DeliveryMethodUserDTO? delivery { get; set; }

        public ICollection<ProductImageUserDTO> images { get; set; } = new List<ProductImageUserDTO>();
    }
}

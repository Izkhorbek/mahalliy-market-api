namespace MahalliyMarket.DTOs.ProductDTOs
{
    // Umumiy Page uchun ishlatiladi
    public class AllProductsUserDTO
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

        public string? primary_image_url { get; set; }

        public string? seller_name { get; set; }

        public ICollection<ProductImageUserDTO> images { get; set; } = new List<ProductImageUserDTO>();

    }
}

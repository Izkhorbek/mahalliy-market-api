namespace MahalliyMarket.DTOs.ProductDTOs
{
    public class ProductImageUserDTO
    {
        public int image_id { get; set; }
        public string image_url { get; set; } = "";
        public string? alt_text { get; set; }
    }
}

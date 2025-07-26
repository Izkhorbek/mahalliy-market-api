namespace MahalliyMarket.DTOs.ProductDTOs
{
    public class ProductSalesUserDTO
    {
        public int sales_id { get; set; }
        public int quantity_sold { get; set; }
        public DateTime sale_date { get; set; }
        public decimal total_price { get; set; }
    }
}

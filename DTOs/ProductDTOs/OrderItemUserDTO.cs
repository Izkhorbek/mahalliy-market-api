namespace MahalliyMarket.DTOs.ProductDTOs
{
    public class OrderItemUserDTO
    {
        public int order_item_id { get; set; }

        public int quantity { get; set; }

        public decimal unit_price { get; set; }

        public decimal dis_percentage { get; set; }

        public decimal final_price { get; set; }
    }
}

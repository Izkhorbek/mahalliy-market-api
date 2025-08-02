namespace MahalliyMarket.DTOs.ProductDTOs
{
    public class FeedbackCreateDTO
    {
        public int customer_id { get; set; }
        public int product_id { get; set; }
        public string comment_text { get; set; }
        public int rating { get; set; }
    }
}


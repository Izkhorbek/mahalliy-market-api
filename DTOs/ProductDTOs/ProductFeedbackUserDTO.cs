namespace MahalliyMarket.DTOs.ProductDTOs
{
    public class ProductFeedbackUserDTO
    {
        public int feedback_id { get; set; }
        public string comment_text { get; set; } = "";
        public int rating { get; set; }  // e.g. 1–5
        public string? customer_name { get; set; }
        public DateTime created_at { get; set; }
    }
}

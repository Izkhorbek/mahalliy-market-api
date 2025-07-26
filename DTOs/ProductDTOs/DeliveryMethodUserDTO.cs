namespace MahalliyMarket.DTOs.ProductDTOs
{
    public class DeliveryMethodUserDTO
    {
        public int method_id { get; set; }

        public string method_name { get; set; }

        public bool is_free { get; set; }

        public decimal delivery_fee { get; set; }

        /// <summary>
        /// Estimated times
        /// </summary>
        public string? estimated_time { get; set; }
    }
}

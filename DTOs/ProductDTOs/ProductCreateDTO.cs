using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MahalliyMarket.DTOs.ProductDTOs
{
    public class ProductCreateDTO
    {
        public int user_id { get; set; }

        [Required(ErrorMessage = "Product Name is required.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Product Name must be between 3 and 100 characters.")]
        public string product_name { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(300, ErrorMessage = "Description must be at most 300 characters long.")]
        public string? product_desc { get; set; }

        [Range(1, 10000000.00, ErrorMessage = "Price must be between $0.01 and $10,000.00.")]
        [Column(TypeName = "decimal(18,4)")]
        [Comment("Haqiqiy qiymayni olish uchun 1000ga ko'paytirib oling.")]
        public decimal product_price { get; set; }

        [Range(0, 1000, ErrorMessage = "Quantity must be between 0 and 1000.")]
        public int product_quantity { get; set; }

        [StringLength(200, ErrorMessage = "Image URL must be at most 200 characters long.")]
        public string? product_tags { get; set; }

        [Range(0, 100, ErrorMessage = "Discount Percentage must be between 0% and 100%.")]
        public int discount_percentage { get; set; }

        // Foreign key to Category
        [Required(ErrorMessage = "Category ID is required.")]
        public int category_id { get; set; }

        /// <summary>
        /// ID of the primary/featured image for this product
        /// </summary>
        public int? primary_image_id { get; set; }
    }
}

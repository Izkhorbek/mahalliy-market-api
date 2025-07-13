using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MahalliyMarket.Models;

public class OrderItem
{
    /// <summary>
    /// Unique identifier for the order item
    /// </summary>
    [Key]
    public int order_item_id { get; set; }

    /// <summary>
    /// ID of the order this item belongs to
    /// </summary>
    [Required(ErrorMessage = "Order ID is required for order item")]
    public int order_id { get; set; }

    /// <summary>
    /// Navigation property to the order
    /// </summary>
    [ForeignKey("order_id")]
    public virtual Order? order { get; set; }

    /// <summary>
    /// ID of the product in this order item
    /// </summary>
    [Required(ErrorMessage = "Product ID is required for order item")]
    public int product_id { get; set; }

    /// <summary>
    /// Navigation property to the product
    /// </summary>
    [ForeignKey("product_id")]
    public virtual Product? product { get; set; }

    /// <summary>
    /// ID of the seller who sold this product
    /// </summary>
    [Required(ErrorMessage = "Seller ID is required for order item")]
    public int seller_id { get; set; }

    /// <summary>
    /// Navigation property to the seller
    /// </summary>
    [ForeignKey("seller_id")]
    public virtual User? seller { get; set; }

    /// <summary>
    /// Quantity of the product ordered
    /// </summary>
    [Required(ErrorMessage = "Quantity is required")]
    [Range(1, 1000, ErrorMessage = "Quantity must be between 1 and 1000")]
    public int quantity { get; set; }

    /// <summary>
    /// Unit price of the product at the time of order
    /// </summary>
    [Required(ErrorMessage = "Unit price is required")]
    [Range(0, 1000000.00, ErrorMessage = "Unit price must be between $0.00 and $1,000,000.00")]
    [Column(TypeName = "decimal(18,2)")]
    public decimal unit_price { get; set; }

    /// <summary>
    /// Discount percentage applied to this item
    /// </summary>
    [Range(0, 100, ErrorMessage = "Discount percentage must be between 0% and 100%")]
    public decimal discount_percentage { get; set; } = 0;

    /// <summary>
    /// Final price after discount for this item
    /// </summary>
    [Required(ErrorMessage = "Final price is required")]
    [Range(0, 1000000.00, ErrorMessage = "Final price must be between $0.00 and $1,000,000.00")]
    [Column(TypeName = "decimal(18,2)")]
    public decimal final_price { get; set; }

    /// <summary>
    /// Product name at the time of order (snapshot)
    /// </summary>
    [Required(ErrorMessage = "Product name is required")]
    [StringLength(200, ErrorMessage = "Product name cannot exceed 200 characters")]
    public string product_name { get; set; } = string.Empty;

    /// <summary>
    /// Product image URL at the time of order (snapshot)
    /// </summary>
    [StringLength(500, ErrorMessage = "Product image URL cannot exceed 500 characters")]
    public string? product_image_url { get; set; }

    /// <summary>
    /// Timestamp when the order item was created
    /// </summary>
    public DateTime created_at { get; set; } = DateTime.UtcNow;
}

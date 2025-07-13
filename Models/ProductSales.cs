using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MahalliyMarket.Models;

public class ProductSales
{
    /// <summary>
    /// Unique identifier for the product sale record
    /// </summary>
    [Key]
    public int sales_id { get; set; }
    
    /// <summary>
    /// ID of the product that was sold
    /// </summary>
    [Required(ErrorMessage = "Product ID is required for sales record")]
    public int product_id { get; set; }
    
    /// <summary>
    /// Navigation property to the product
    /// </summary>
    [ForeignKey("product_id")]
    public virtual Product? product { get; set; }
    
    /// <summary>
    /// Quantity of products sold
    /// </summary>
    [Required(ErrorMessage = "Quantity is required")]
    [Range(1, 1000, ErrorMessage = "Quantity must be between 1 and 1000")]
    public int quantity { get; set; }
    
    /// <summary>
    /// Date when the sale occurred
    /// </summary>
    [Required(ErrorMessage = "Sale date is required")]
    public DateTime sale_date { get; set; }
    
    /// <summary>
    /// Unit price at the time of sale
    /// </summary>
    [Required(ErrorMessage = "Unit price is required")]
    [Range(0.01, 1000000.00, ErrorMessage = "Unit price must be between $0.01 and $1,000,000.00")]
    [Column(TypeName = "decimal(18,2)")]
    public decimal unit_price { get; set; }
    
    /// <summary>
    /// Total amount of the sale (quantity * unit_price)
    /// </summary>
    [Required(ErrorMessage = "Total amount is required")]
    [Range(0.01, 1000000.00, ErrorMessage = "Total amount must be between $0.01 and $1,000,000.00")]
    [Column(TypeName = "decimal(18,2)")]
    public decimal total_amount { get; set; }
    
    /// <summary>
    /// Discount percentage applied to the sale
    /// </summary>
    [Range(0, 100, ErrorMessage = "Discount percentage must be between 0% and 100%")]
    public decimal discount_percentage { get; set; } = 0;
    
    /// <summary>
    /// Discount amount in currency
    /// </summary>
    [Range(0, 1000000.00, ErrorMessage = "Discount amount must be between $0.00 and $1,000,000.00")]
    [Column(TypeName = "decimal(18,2)")]
    public decimal discount_amount { get; set; } = 0;
    
    /// <summary>
    /// Final amount after discount
    /// </summary>
    [Required(ErrorMessage = "Final amount is required")]
    [Range(0.01, 1000000.00, ErrorMessage = "Final amount must be between $0.01 and $1,000,000.00")]
    [Column(TypeName = "decimal(18,2)")]
    public decimal final_amount { get; set; }
    
    /// <summary>
    /// ID of the customer who made the purchase
    /// </summary>
    [Required(ErrorMessage = "Customer ID is required")]
    public int customer_id { get; set; }
    
    /// <summary>
    /// Navigation property to the customer
    /// </summary>
    [ForeignKey("customer_id")]
    public virtual User? customer { get; set; }
    
    /// <summary>
    /// ID of the seller/business who sold the product
    /// </summary>
    [Required(ErrorMessage = "Seller ID is required")]
    public int seller_id { get; set; }
    
    /// <summary>
    /// Navigation property to the seller
    /// </summary>
    [ForeignKey("seller_id")]
    public virtual User? seller { get; set; }
    
    /// <summary>
    /// ID of the order this sale is part of
    /// </summary>
    public int? order_id { get; set; }
    
    /// <summary>
    /// Navigation property to the order
    /// </summary>
    [ForeignKey("order_id")]
    public virtual Order? order { get; set; }
    
    /// <summary>
    /// Payment method used for the sale
    /// </summary>
    [StringLength(50, ErrorMessage = "Payment method cannot exceed 50 characters")]
    public string? payment_method { get; set; }
    
    /// <summary>
    /// Payment status of the sale
    /// </summary>
    [StringLength(20, ErrorMessage = "Payment status cannot exceed 20 characters")]
    public string payment_status { get; set; } = "Completed";
    
    /// <summary>
    /// Sales channel (Online, In-Store, Phone, etc.)
    /// </summary>
    [StringLength(30, ErrorMessage = "Sales channel cannot exceed 30 characters")]
    public string? sales_channel { get; set; }
    
    /// <summary>
    /// Location where the sale occurred
    /// </summary>
    [StringLength(200, ErrorMessage = "Sale location cannot exceed 200 characters")]
    public string? sale_location { get; set; }
    
    /// <summary>
    /// Notes or comments about the sale
    /// </summary>
    [StringLength(500, ErrorMessage = "Sale notes cannot exceed 500 characters")]
    public string? sale_notes { get; set; }
    
    /// <summary>
    /// Indicates if this sale is active and valid
    /// </summary>
    public bool is_active { get; set; } = true;
    
    /// <summary>
    /// Indicates if this sale has been refunded
    /// </summary>
    public bool is_refunded { get; set; } = false;
    
    /// <summary>
    /// Timestamp when the sale was recorded
    /// </summary>
    public DateTime created_at { get; set; } = DateTime.UtcNow;
    
    /// <summary>
    /// Timestamp when the sale was last updated
    /// </summary>
    public DateTime updated_at { get; set; } = DateTime.UtcNow;
    
    /// <summary>
    /// Timestamp when the sale was refunded (if applicable)
    /// </summary>
    public DateTime? refunded_at { get; set; }
}

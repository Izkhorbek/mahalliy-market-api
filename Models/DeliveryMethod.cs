using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MahalliyMarket.Models;

public class DeliveryMethod
{
    /// <summary>
    /// Unique identifier for the delivery method
    /// </summary>
    [Key]
    public int delivery_method_id { get; set; }

    /// <summary>
    /// ID of the seller/business offering this delivery method
    /// </summary>
    [Required(ErrorMessage = "Seller ID is required")]
    public int seller_id { get; set; }

    /// <summary>
    /// Navigation property to the seller
    /// </summary>
    [ForeignKey("seller_id")]
    public User? seller { get; set; }

    /// <summary>
    /// ID of the seller/business offering this delivery method
    /// </summary>
    [Required(ErrorMessage = "Product ID is required")]
    public int product_id { get; set; }

    /// <summary>
    /// Navigation property to the product
    /// </summary>
    [ForeignKey("product_id")]
    public Product? product { get; set; }


    /// <summary>
    /// Name/title of the delivery method
    /// </summary>
    [Required(ErrorMessage = "Delivery method name is required")]
    [StringLength(100, ErrorMessage = "Delivery method name cannot exceed 100 characters")]
    public string method_name { get; set; } = string.Empty;

    /// <summary>
    /// Description of the delivery method
    /// </summary>
    [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters")]
    public string? description { get; set; }

    /// <summary>
    /// Indicates if delivery is free
    /// </summary>
    public bool is_free_delivery { get; set; } = false;

    /// <summary>
    /// Delivery fee amount
    /// </summary>
    [Range(0, 1000000.00, ErrorMessage = "Delivery fee must be between $0.00 and $1,000,000.00")]
    [Column(TypeName = "decimal(18,2)")]
    public decimal delivery_fee { get; set; } = 0;

    /// <summary>
    /// Indicates if installation service is available
    /// </summary>
    public bool can_install { get; set; } = false;

    /// <summary>
    /// Installation fee amount
    /// </summary>
    [Range(0, 1000000.00, ErrorMessage = "Installation fee must be between $0.00 and $1,000,000.00")]
    [Column(TypeName = "decimal(18,2)")]
    public decimal installation_fee { get; set; } = 0;

    /// <summary>
    /// Number of days for delivery
    /// </summary>
    [Range(0, 365, ErrorMessage = "Delivery days must be between 0 and 365")]
    public string estimated_time { get; set; }

    /// <summary>
    /// Maximum weight for delivery in kg
    /// </summary>
    [Range(0, 1000, ErrorMessage = "Maximum weight must be between 0 and 1000 kg")]
    public decimal? max_weight { get; set; }

    /// <summary>
    /// Indicates if this method is active and available
    /// </summary>
    public bool is_active { get; set; } = true;

    /// <summary>
    /// Timestamp when the delivery method was created
    /// </summary>
    public DateTime created_at { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Timestamp when the delivery method was last updated
    /// </summary>
    public DateTime? updated_at { get; set; }

}
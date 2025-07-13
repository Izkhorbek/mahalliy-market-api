using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MahalliyMarket.Models;

public class ShippingMethod
{
    /// <summary>
    /// Unique identifier for the shipping method
    /// </summary>
    [Key]
    public int shipping_method_id { get; set; }
    
    /// <summary>
    /// ID of the product this shipping method belongs to
    /// </summary>
    [Required(ErrorMessage = "Product ID is required")]
    public int product_id { get; set; }

    /// <summary>
    /// ID of the seller/business offering this shipping method
    /// </summary>
    [Required(ErrorMessage = "Seller ID is required")]
    public int seller_id { get; set; }
    
    /// <summary>
    /// Navigation property to the seller
    /// </summary>
    [ForeignKey("seller_id")]
    public virtual User? seller { get; set; }
    
    /// <summary>
    /// Name/title of the shipping method
    /// </summary>
    [Required(ErrorMessage = "Shipping method name is required")]
    [StringLength(100, ErrorMessage = "Shipping method name cannot exceed 100 characters")]
    public string method_name { get; set; } = string.Empty;
    
    /// <summary>
    /// Description of the shipping method and write about shippign region,
    /// </summary>
    [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters")]
    public string? description { get; set; }
    
    /// <summary>
    /// Indicates if the seller can deliver products
    /// </summary>
    public bool can_deliver { get; set; } = true;
    
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
    
//     /// <summary>
//     /// Minimum order amount for free delivery
//     /// </summary>
//     [Range(0, 1000000.00, ErrorMessage = "Free delivery minimum must be between $0.00 and $1,000,000.00")]
//     [Column(TypeName = "decimal(18,2)")]
//     public decimal? free_delivery_minimum { get; set; }
    
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
    /// Indicates if installation is free
    /// </summary>
    public bool is_free_installation { get; set; } = false;
    
    /// <summary>
    /// Minimum order amount for free installation
    /// </summary>
    [Range(0, 1000000.00, ErrorMessage = "Free installation minimum must be between $0.00 and $1,000,000.00")]
    [Column(TypeName = "decimal(18,2)")]
    public decimal? free_installation_minimum { get; set; }
    
    /// <summary>
    /// Number of days for delivery
    /// </summary>
    [Range(0, 365, ErrorMessage = "Delivery days must be between 0 and 365")]
    public int delivery_days { get; set; } = 1;
    
//     /// <summary>
//     /// Number of days for installation (after delivery)
//     /// </summary>
//     [Range(0, 30, ErrorMessage = "Installation days must be between 0 and 30")]
//     public int installation_days { get; set; } = 0;
    
//     /// <summary>
//     /// Maximum delivery distance in kilometers
//     /// </summary>
//     [Range(0, 1000, ErrorMessage = "Maximum distance must be between 0 and 1000 km")]
//     public decimal? max_delivery_distance { get; set; }
    
//     /// <summary>
//     /// Geographic regions where this method is available
//     /// </summary>
//     [StringLength(500, ErrorMessage = "Available regions cannot exceed 500 characters")]
//     public string? available_regions { get; set; }
    
//     /// <summary>
//     /// Delivery time window (e.g., "9 AM - 6 PM")
//     /// </summary>
//     [StringLength(100, ErrorMessage = "Delivery time window cannot exceed 100 characters")]
//     public string? delivery_time_window { get; set; }
    
//     /// <summary>
//     /// Installation time window (e.g., "10 AM - 4 PM")
//     /// </summary>
//     [StringLength(100, ErrorMessage = "Installation time window cannot exceed 100 characters")]
//     public string? installation_time_window { get; set; }
    
    /// <summary>
    /// Maximum weight for delivery
    /// </summary>
    [Range(0, 1000, ErrorMessage = "Maximum weight must be between 0 and 1000 kg")]
    public decimal? max_weight { get; set; }
    
//     /// <summary>
//     /// Maximum dimensions for delivery
//     /// </summary>
//     [StringLength(100, ErrorMessage = "Maximum dimensions cannot exceed 100 characters")]
//     public string? max_dimensions { get; set; }
    
//     /// <summary>
//     /// Special delivery instructions
//     /// </summary>
//     [StringLength(300, ErrorMessage = "Delivery instructions cannot exceed 300 characters")]
//     public string? delivery_instructions { get; set; }
    
//     /// <summary>
//     /// Special installation instructions
//     /// </summary>
//     [StringLength(300, ErrorMessage = "Installation instructions cannot exceed 300 characters")]
//     public string? installation_instructions { get; set; }
    
    /// <summary>
    /// Indicates if this method is active and available
    /// </summary>
    public bool is_active { get; set; } = true;
    
//     /// <summary>
//     /// Indicates if this is the default shipping method
//     /// </summary>
//     public bool is_default { get; set; } = false;
    
//     /// <summary>
//     /// Indicates if tracking is available
//     /// </summary>
//     public bool has_tracking { get; set; } = false;
    
    /// <summary>
    /// Indicates if insurance is included
    /// </summary>
    public bool has_insurance { get; set; } = false;
    
    /// <summary>
    /// Insurance amount if included
    /// </summary>
    [Range(0, 1000000.00, ErrorMessage = "Insurance amount must be between $0.00 and $1,000,000.00")]
    [Column(TypeName = "decimal(18,2)")]
    public decimal? insurance_amount { get; set; }
    
    /// <summary>
    /// Timestamp when the shipping method was created
    /// </summary>
    public DateTime created_at { get; set; } = DateTime.UtcNow;
    
    /// <summary>
    /// Timestamp when the shipping method was last updated
    /// </summary>
    public DateTime updated_at { get; set; } = DateTime.UtcNow;
}
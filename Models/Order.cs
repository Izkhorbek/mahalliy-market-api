using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MahalliyMarket.Models;

public class Order
{
    /// <summary>
    /// Unique identifier for the order
    /// </summary>
    [Key]
    public int order_id { get; set; }

    /// <summary>
    /// Unique order number in format "ORD-UTC time+ id"
    /// Example: "ORD-20241201143022-001"
    /// </summary>
    [Required(ErrorMessage = "Order number is required")]
    [StringLength(50, ErrorMessage = "Order number cannot exceed 50 characters")]
    public string order_number { get; set; } = string.Empty;

    /// <summary>
    /// Date and time when the order was placed
    /// </summary>
    [Required(ErrorMessage = "Order date is required")]
    public DateTime order_date { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// ID of the customer who placed the order
    /// </summary>
    [Required(ErrorMessage = "Customer ID is required")]
    public int customer_id { get; set; }

    /// <summary>
    /// Navigation property to the customer
    /// </summary>
    [ForeignKey("customer_id")]
    public User? customer { get; set; }

    /// <summary>
    /// ID of the delivery address for this order
    /// </summary>
    [Required(ErrorMessage = "Delivery address ID is required")]
    public int delivery_address_id { get; set; }

    /// <summary>
    /// Navigation property to the delivery address
    /// </summary>
    [ForeignKey("delivery_address_id")]
    public DeliveryAddress? delivery_address { get; set; }

    /// <summary>
    /// Total base amount before discounts and delivery
    /// </summary>
    [Required(ErrorMessage = "Total base amount is required")]
    [Range(0, 1000000.00, ErrorMessage = "Total base amount must be between $0.00 and $1,000,000.00")]
    [Column(TypeName = "decimal(18,2)")]
    public decimal total_base_amount { get; set; }

    /// <summary>
    /// Total discount amount applied to the order
    /// </summary>
    [Range(0, 1000000.00, ErrorMessage = "Total discount amount must be between $0.00 and $1,000,000.00")]
    [Column(TypeName = "decimal(18,2)")]
    public decimal total_discount_amount { get; set; } = 0;

    /// <summary>
    /// Delivery cost for the order
    /// </summary>
    [Range(0, 10000.00, ErrorMessage = "Delivery cost must be between $0.00 and $10,000.00")]
    [Column(TypeName = "decimal(18,2)")]
    public decimal delivery_cost { get; set; } = 0;

    /// <summary>
    /// ID of the delivery method used
    /// </summary>
    public int? delivery_method_id { get; set; }

    /// <summary>
    /// Navigation property to the delivery method
    /// </summary>
    [ForeignKey("delivery_method_id")]
    public DeliveryMethod? delivery_method { get; set; }

    /// <summary>
    /// Current status of the order
    /// </summary>
    [Required(ErrorMessage = "Order status is required")]
    public EOrderStatus order_status { get; set; } = EOrderStatus.Pending;

    /// <summary>
    /// Final total amount after all calculations
    /// </summary>
    [Required(ErrorMessage = "Total amount is required")]
    [Range(0, 1000000.00, ErrorMessage = "Total amount must be between $0.00 and $1,000,000.00")]
    [Column(TypeName = "decimal(18,2)")]
    public decimal total_amount { get; set; }

    /// <summary>
    /// Currency for the order (default: UZS)
    /// </summary>
    [Required(ErrorMessage = "Currency is required")]
    [StringLength(3, MinimumLength = 3, ErrorMessage = "Currency must be exactly 3 characters")]
    public string currency { get; set; } = "UZS";

    /// <summary>
    /// Expected delivery date
    /// </summary>
    public DateTime? expected_delivery_date { get; set; }

    /// <summary>
    /// Linked with associated  payment
    /// </summary>
    public Payment? payment { get; set; }

    /// <summary>
    /// Timestamp when the order was created
    /// </summary>
    public DateTime created_at { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Collection of order items in this order
    /// </summary>
    public ICollection<OrderItem> order_items { get; set; } = new List<OrderItem>();
}

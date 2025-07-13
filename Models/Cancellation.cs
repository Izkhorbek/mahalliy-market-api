using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MahalliyMarket.Models;

public class Cancellation
{
    /// <summary>
    /// Unique identifier for the cancellation
    /// </summary>
    [Key]
    public int cancellation_id { get; set; }
    
    /// <summary>
    /// ID of the order being cancelled
    /// </summary>
    [Required(ErrorMessage = "Order ID is required for cancellation")]
    public int order_id { get; set; }
    
    /// <summary>
    /// Navigation property to the order
    /// </summary>
    [ForeignKey("order_id")]
    public virtual Order? order { get; set; }
    
    /// <summary>
    /// ID of the customer requesting cancellation
    /// </summary>
    [Required(ErrorMessage = "Customer ID is required")]
    public int customer_id { get; set; }
    
    /// <summary>
    /// Navigation property to the customer
    /// </summary>
    [ForeignKey("customer_id")]
    public virtual User? customer { get; set; }
    
    /// <summary>
    /// ID of the seller/business
    /// </summary>
    [Required(ErrorMessage = "Seller ID is required")]
    public int seller_id { get; set; }
    
    /// <summary>
    /// Navigation property to the seller
    /// </summary>
    [ForeignKey("seller_id")]
    public virtual User? seller { get; set; }
    
    /// <summary>
    /// Reason for cancellation
    /// </summary>
    [Required(ErrorMessage = "Cancellation reason is required")]
    [StringLength(500, MinimumLength = 10, ErrorMessage = "Cancellation reason must be between 10 and 500 characters")]
    public string reason { get; set; } = string.Empty;
    
    /// <summary>
    /// Status of the cancellation request
    /// </summary>
    [Required(ErrorMessage = "Cancellation status is required")]
    public string status { get; set; } = "Pending";
    
    /// <summary>
    /// Timestamp when cancellation was requested
    /// </summary>
    public DateTime requested_at { get; set; } = DateTime.UtcNow;
    
    /// <summary>
    /// Timestamp when cancellation was processed
    /// </summary>
    public DateTime? processed_at { get; set; }
    
    /// <summary>
    /// ID of the user who processed the cancellation
    /// </summary>
    public int? processed_by { get; set; }
    
    /// <summary>
    /// Navigation property to the user who processed the cancellation
    /// </summary>
    [ForeignKey("processed_by")]
    public virtual User? processor { get; set; }
    
    /// <summary>
    /// Refund amount after deducting cancellation charges
    /// </summary>
    [Range(0, 1000000.00, ErrorMessage = "Refund amount must be between $0.00 and $1,000,000.00")]
    [Column(TypeName = "decimal(18,2)")]
    public decimal refund_amount { get; set; }
    
    /// <summary>
    /// Additional remarks or notes about the cancellation
    /// </summary>
    [StringLength(1000, ErrorMessage = "Remarks cannot exceed 1000 characters")]
    public string? remarks { get; set; }
    
    /// <summary>
    /// Timestamp when the cancellation record was created
    /// </summary>
    public DateTime created_at { get; set; } = DateTime.UtcNow;
}

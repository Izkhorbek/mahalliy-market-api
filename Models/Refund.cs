using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MahalliyMarket.Models;

public class Refund
{
    /// <summary>
    /// Unique identifier for the refund
    /// </summary>
    [Key]
    public int refund_id { get; set; }

    /// <summary>
    /// Unique identifier for the cancellation
    /// </summary>
    public int cancellation_id { get; set; }

    /// <summary>
    /// Navigation property to the Cancellation
    /// </summary>
    [ForeignKey("cancellation_id")]
    public Cancellation? cancellation { get; set; }

    /// <summary>
    /// ID of the order being refunded
    /// </summary>
    [Required(ErrorMessage = "Order ID is required for refund")]
    public int order_id { get; set; }

    /// <summary>
    /// Navigation property to the order
    /// </summary>
    [ForeignKey("order_id")]
    public Order? order { get; set; }

    /// <summary>
    /// ID of the payment being refunded
    /// </summary>
    [Required(ErrorMessage = "Payment ID is required for refund")]
    public int payment_id { get; set; }

    /// <summary>
    /// Navigation property to the payment
    /// </summary>
    [ForeignKey("payment_id")]
    public Payment? payment { get; set; }

    /// <summary>
    /// ID of the customer requesting refund
    /// </summary>
    [Required(ErrorMessage = "Customer ID is required")]
    public int customer_id { get; set; }

    /// <summary>
    /// Navigation property to the customer
    /// </summary>
    [ForeignKey("customer_id")]
    public User? customer { get; set; }

    /// <summary>
    /// ID of the seller/business
    /// </summary>
    [Required(ErrorMessage = "Seller ID is required")]
    public int seller_id { get; set; }

    /// <summary>
    /// Navigation property to the seller
    /// </summary>
    [ForeignKey("seller_id")]
    public User? seller { get; set; }

    /// <summary>
    /// Original payment amount
    /// </summary>
    [Required(ErrorMessage = "Original amount is required")]
    [Range(0.01, 1000000.00, ErrorMessage = "Original amount must be between $0.01 and $1,000,000.00")]
    [Column(TypeName = "decimal(18,2)")]
    public decimal original_amount { get; set; }

    /// <summary>
    /// Amount to be refunded
    /// </summary>
    [Required(ErrorMessage = "Refund amount is required")]
    [Range(0.01, 1000000.00, ErrorMessage = "Refund amount must be between $0.01 and $1,000,000.00")]
    [Column(TypeName = "decimal(18,2)")]
    public decimal refund_amount { get; set; }

    /// <summary>
    /// Processing fee for the refund
    /// </summary>
    [Range(0, 1000000.00, ErrorMessage = "Processing fee must be between $0.00 and $1,000,000.00")]
    [Column(TypeName = "decimal(18,2)")]
    public decimal processing_fee { get; set; } = 0;

    /// <summary>
    /// Net refund amount after deducting processing fee
    /// </summary>
    [Range(0, 1000000.00, ErrorMessage = "Net refund amount must be between $0.00 and $1,000,000.00")]
    [Column(TypeName = "decimal(18,2)")]
    public decimal net_refund_amount { get; set; }

    /// <summary>
    /// Reason for the refund
    /// </summary>
    [Required(ErrorMessage = "Refund reason is required")]
    [StringLength(500, MinimumLength = 10, ErrorMessage = "Refund reason must be between 10 and 500 characters")]
    public string reason { get; set; } = string.Empty;

    /// <summary>
    /// Status of the refund request
    /// </summary>
    [Required(ErrorMessage = "Refund status is required")]
    public string status { get; set; } = "Pending";

    /// <summary>
    /// Refund method (Bank Transfer, Card Refund, Cash, etc.)
    /// </summary>
    [Required(ErrorMessage = "Refund method is required")]
    [StringLength(50, ErrorMessage = "Refund method cannot exceed 50 characters")]
    public string refund_method { get; set; } = string.Empty;

    /// <summary>
    /// Timestamp when refund was requested
    /// </summary>
    public DateTime requested_at { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Timestamp when refund was approved
    /// </summary>
    public DateTime? approved_at { get; set; }

    /// <summary>
    /// Timestamp when refund was processed
    /// </summary>
    public DateTime? processed_at { get; set; }

    /// <summary>
    /// Timestamp when refund was completed
    /// </summary>
    public DateTime? completed_at { get; set; }

    /// <summary>
    /// ID of the user who approved the refund
    /// </summary>
    public int? approved_by { get; set; }

    /// <summary>
    /// Navigation property to the user who approved the refund
    /// </summary>
    [ForeignKey("approved_by")]
    public User? approver { get; set; }

    /// <summary>
    /// ID of the user who processed the refund
    /// </summary>
    public int? processed_by { get; set; }

    /// <summary>
    /// Navigation property to the user who processed the refund
    /// </summary>
    [ForeignKey("processed_by")]
    public User? processor { get; set; }

    /// <summary>
    /// Transaction ID for the refund
    /// </summary>
    [StringLength(100, ErrorMessage = "Transaction ID cannot exceed 100 characters")]
    public string? transaction_id { get; set; }

    /// <summary>
    /// Reference number for the refund
    /// </summary>
    [StringLength(50, ErrorMessage = "Reference number cannot exceed 50 characters")]
    public string? reference_number { get; set; }

    /// <summary>
    /// Bank account number for bank transfer refunds
    /// </summary>
    [StringLength(50, ErrorMessage = "Bank account number cannot exceed 50 characters")]
    public string? bank_account { get; set; }

    /// <summary>
    /// Bank name for bank transfer refunds
    /// </summary>
    [StringLength(100, ErrorMessage = "Bank name cannot exceed 100 characters")]
    public string? bank_name { get; set; }

    /// <summary>
    /// Card last 4 digits for card refunds
    /// </summary>
    [StringLength(4, MinimumLength = 4, ErrorMessage = "Card last 4 digits must be exactly 4 characters")]
    public string? card_last_four { get; set; }

    /// <summary>
    /// Refund type (Full, Partial, etc.)
    /// </summary>
    [StringLength(20, ErrorMessage = "Refund type cannot exceed 20 characters")]
    public string? refund_type { get; set; }

    // /// <summary>
    // /// Priority level of the refund request
    // /// </summary>
    // public int priority { get; set; } = 1;

    /// <summary>
    /// Indicates if refund is urgent
    /// </summary>
    public bool is_urgent { get; set; } = false;

    /// <summary>
    /// Additional notes about the refund
    /// </summary>
    [StringLength(1000, ErrorMessage = "Notes cannot exceed 1000 characters")]
    public string? notes { get; set; }

    /// <summary>
    /// Indicates if customer was notified about refund
    /// </summary>
    public bool customer_notified { get; set; } = false;

    /// <summary>
    /// Indicates if seller was notified about refund
    /// </summary>
    public bool seller_notified { get; set; } = false;

    /// <summary>
    /// Timestamp when customer was notified
    /// </summary>
    public DateTime? customer_notified_at { get; set; }

    /// <summary>
    /// Timestamp when seller was notified
    /// </summary>
    public DateTime? seller_notified_at { get; set; }

    /// <summary>
    /// Indicates if the refund is active and valid
    /// </summary>
    public bool is_active { get; set; } = true;

    /// <summary>
    /// Timestamp when the refund record was created
    /// </summary>
    public DateTime created_at { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Timestamp when the refund record was last updated
    /// </summary>
    public DateTime updated_at { get; set; } = DateTime.UtcNow;
}
// Relationships Established:
// Order → Refund (one-to-many)
// Payment → Refund (one-to-many)
// User (Customer) → Refund (one-to-many)
// User (Seller) → Refund (one-to-many)
// User (Approver) → Refund (one-to-many, optional)
// User (Processor) → Refund (one-to-many, optional)

/*
    Core Properties:
        Basic Information:
        refund_id: Primary key for the refund
        order_id: Links to the order being refunded
        payment_id: Links to the payment being refunded
        customer_id: Who requested the refund
        seller_id: The seller/business involved
        Financial Tracking:
        original_amount: Original payment amount

    Financial Tracking:
        original_amount: Original payment amount
        refund_amount: Amount to be refunded
        processing_fee: Fee for processing the refund
        net_refund_amount: Final amount after deducting fees

    Process Management:
        reason: Refund reason (10-500 chars)
        status: Status of the refund request
        refund_method: How the refund will be processed
        refund_type: Type of refund (Full, Partial)

    Timeline Tracking:
        requested_at: When refund was requested
        approved_at: When refund was approved
        processed_at: When refund was processed
        completed_at: When refund was completed

    Approval & Processing:
        approved_by: Who approved the refund
        processed_by: Who processed the refund
        approver: Navigation property to approver
        processor: Navigation property to processor.

    Payment Details:
        transaction_id: External transaction ID
        reference_number: Reference number for tracking
        bank_account: Bank account for transfers
        bank_name: Bank name for transfers
        card_last_four: Card details for card refunds

    Management Features:
        priority: Priority level of the request
        is_urgent: Marks urgent refunds
        notes: Additional notes (1000 chars max)

    Notification Tracking:
        customer_notified: Whether customer was notified
        seller_notified: Whether seller was notified
        customer_notified_at: When customer was notified
        seller_notified_at: When seller was notified

    Status Management:
        is_active: Enable/disable refund records
        created_at: Creation timestamp
        updated_at: Last modification timestamp

Key Features for Your Local Market:
Comprehensive Refund Tracking:
        Full audit trail of refund requests
        Financial impact tracking
        Multi-step approval process
Flexible Refund Methods:
        Bank transfers for local businesses
        Card refunds for online payments
        Cash refunds for in-person transactions
Business Process Support:
        Priority-based processing
        Urgent refund handling
        Automated notification system    
*/
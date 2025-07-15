using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MahalliyMarket.Models;

public class Payment
{
    /// <summary>
    /// Unique identifier for the payment
    /// </summary>
    [Key]
    public int payment_id { get; set; }

    /// <summary>
    /// ID of the order this payment is for
    /// </summary>
    [Required(ErrorMessage = "Order ID is required for payment")]
    public int order_id { get; set; }

    /// <summary>
    /// Navigation property to the order
    /// </summary>
    [ForeignKey("order_id")]
    public Order? order { get; set; }

    /// <summary>
    /// ID of the customer making the payment
    /// </summary>
    [Required(ErrorMessage = "Customer ID is required")]
    public int customer_id { get; set; }

    /// <summary>
    /// Navigation property to the customer
    /// </summary>
    [ForeignKey("customer_id")]
    public User? customer { get; set; }

    /// <summary>
    /// Amount being paid
    /// </summary>
    [Required(ErrorMessage = "Payment amount is required")]
    [Range(0.01, 1000000.00, ErrorMessage = "Payment amount must be between $0.01 and $1,000,000.00")]
    [Column(TypeName = "decimal(18,2)")]
    public decimal amount { get; set; }

    /// <summary>
    /// Currency of the payment (e.g., "UZS", "USD", "EUR")
    /// </summary>
    [Required(ErrorMessage = "Currency is required")]
    [StringLength(3, MinimumLength = 3, ErrorMessage = "Currency must be exactly 3 characters")]
    public string currency { get; set; } = "UZS";

    /// <summary>
    /// Payment method used (Cash, Card, Bank Transfer, etc.)
    /// </summary>
    [Required(ErrorMessage = "Payment method is required")]
    public EPaymentMethod payment_method { get; set; } = EPaymentMethod.Cash;

    /// <summary>
    /// Status of the payment (Pending, Completed, Failed, Refunded)
    /// </summary>
    [Required(ErrorMessage = "Payment status is required")]
    public EPaymentStatus payment_status { get; set; } = EPaymentStatus.Pending;

    /// <summary>
    /// Transaction ID from payment gateway/bank
    /// </summary>
    [StringLength(100, ErrorMessage = "Transaction ID cannot exceed 100 characters")]
    public string? transaction_id { get; set; }

    /// <summary>
    /// Reference number for the payment
    /// </summary>
    [StringLength(50, ErrorMessage = "Reference number cannot exceed 50 characters")]
    public string? reference_number { get; set; }

    /// <summary>
    /// Payment gateway used (PayPal, Stripe, Local Bank, etc.)
    /// </summary>
    [StringLength(50, ErrorMessage = "Payment gateway cannot exceed 50 characters")]
    public string? payment_gateway { get; set; }

    /// <summary>
    /// Bank account number (for bank transfers)
    /// </summary>
    [StringLength(50, ErrorMessage = "Bank account number cannot exceed 50 characters")]
    public string? bank_account { get; set; }

    /// <summary>
    /// Card last 4 digits (for card payments)
    /// </summary>
    [StringLength(4, MinimumLength = 4, ErrorMessage = "Card last 4 digits must be exactly 4 characters")]
    public string? card_last_four { get; set; }

    /// <summary>
    /// Card type (Visa, MasterCard, etc.)
    /// </summary>
    [StringLength(20, ErrorMessage = "Card type cannot exceed 20 characters")]
    public string? card_type { get; set; }

    /// <summary>
    /// Payment processing fee
    /// </summary>
    [Range(0, 1000000.00, ErrorMessage = "Processing fee must be between $0.00 and $1,000,000.00")]
    [Column(TypeName = "decimal(18,2)")]
    public decimal processing_fee { get; set; } = 0;

    /// <summary>
    /// Tax amount on the payment
    /// </summary>
    [Range(0, 1000000.00, ErrorMessage = "Tax amount must be between $0.00 and $1,000,000.00")]
    [Column(TypeName = "decimal(18,2)")]
    public decimal tax_amount { get; set; } = 0;

    /// <summary>
    /// Exchange rate if payment is in different currency
    /// </summary>
    [Range(0.0001, 10000.00, ErrorMessage = "Exchange rate must be between 0.0001 and 10000.00")]
    [Column(TypeName = "decimal(18,6)")]
    public decimal? exchange_rate { get; set; }

    /// <summary>
    /// Amount in base currency after exchange
    /// </summary>
    [Range(0.01, 1000000.00, ErrorMessage = "Base amount must be between $0.01 and $1,000,000.00")]
    [Column(TypeName = "decimal(18,2)")]
    public decimal? base_amount { get; set; }

    /// <summary>
    /// Date when payment was initiated
    /// </summary>
    public DateTime payment_date { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Date when payment was processed/completed
    /// </summary>
    public DateTime? processed_date { get; set; }

    /// <summary>
    /// Date when payment was refunded (if applicable)
    /// </summary>
    public DateTime? refunded_date { get; set; }

    /// <summary>
    /// Reason for payment failure (if applicable)
    /// </summary>
    [StringLength(500, ErrorMessage = "Failure reason cannot exceed 500 characters")]
    public string? failure_reason { get; set; }

    /// <summary>
    /// Additional notes about the payment
    /// </summary>
    [StringLength(1000, ErrorMessage = "Payment notes cannot exceed 1000 characters")]
    public string? payment_notes { get; set; }

    /// <summary>
    /// Indicates if this payment is active and valid
    /// </summary>
    public bool is_active { get; set; } = true;

    /// <summary>
    /// Timestamp when the payment record was created
    /// </summary>
    public DateTime created_at { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Timestamp when the payment record was last updated
    /// </summary>
    public DateTime updated_at { get; set; } = DateTime.UtcNow;
}

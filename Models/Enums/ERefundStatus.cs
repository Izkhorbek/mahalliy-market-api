namespace MahalliyMarket.Models;

/// <summary>
/// Enumeration for refund status
/// </summary>
 
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ERefundStatus
{
    /// <summary>
    /// Refund is pending processing
    /// </summary>
    Pending = 1,
    
    /// <summary>
    /// Refund has been approved
    /// </summary>
    Approved = 8,
    
    /// <summary>
    /// Refund is being processed
    /// </summary>
    Processing = 3,
    
    /// <summary>
    /// Refund has been completed successfully
    /// </summary>
    Completed = 4,
    
    /// <summary>
    /// Refund has failed
    /// </summary>
    Failed = 5,
    
    /// <summary>
    /// Refund has been cancelled
    /// </summary>
    Cancelled = 6,

    /// <summary>
    /// Payment has been refunded
    /// </summary>
    Refunded = 7,
}

namespace MahalliyMarket.Models;

/// <summary>
/// Enumeration for payment status
/// </summary>
public enum EPaymentStatus
{
    /// <summary>
    /// Payment is pending processing
    /// </summary>
    Pending = 1,
    
    /// <summary>
    /// Payment is being processed
    /// </summary>
    Processing = 2,
    
    /// <summary>
    /// Payment has been completed successfully
    /// </summary>
    Completed = 3,
    
    /// <summary>
    /// Payment has failed
    /// </summary>
    Failed = 4,
    
    /// <summary>
    /// Payment has been cancelled
    /// </summary>
    Cancelled = 5,
    
    /// <summary>
    /// Payment has been refunded
    /// </summary>
    Refunded = 6,
    
    /// <summary>
    /// Payment is on hold
    /// </summary>
    OnHold = 7,
    
    /// <summary>
    /// Payment is disputed
    /// </summary>
    Disputed = 8,
    
    /// <summary>
    /// Payment has expired
    /// </summary>
    Expired = 9,
    
    /// <summary>
    /// Payment is partially refunded
    /// </summary>
    PartiallyRefunded = 10,
    
    /// <summary>
    /// Payment is awaiting confirmation
    /// </summary>
    AwaitingConfirmation = 11,
    
    /// <summary>
    /// Payment is being reviewed
    /// </summary>
    UnderReview = 12
}

using System.Text.Json.Serialization;

namespace MahalliyMarket.Models;

/// <summary>
/// Enumeration for payment status
/// </summary>

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum EPaymentStatus
{
    /// <summary>
    /// Payment is pending processing
    /// </summary>
    Pending = 1,
    
    /// <summary>
    /// Payment has been confirmed
    /// </summary>
    Confirmed = 2,
    
    /// <summary>
    /// Payment is being processed
    /// </summary>
    Processing = 3,
    
    /// <summary>
    /// Payment has been completed successfully
    /// </summary>
    Completed = 4,
    
    /// <summary>
    /// Payment has failed
    /// </summary>
    Failed = 5,
    
    /// <summary>
    /// Payment has been cancelled
    /// </summary>
    Cancelled = 6,
    
    /// <summary>
    /// Payment has been refunded
    /// </summary>
    Refunded = 7,
}

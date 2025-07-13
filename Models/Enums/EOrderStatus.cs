using System.Text.Json.Serialization;

namespace MahalliyMarket.Models;

/// <summary>
/// Enumeration for order status
/// </summary>

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum EOrderStatus
{
    /// <summary>
    /// Order has been placed but not yet confirmed
    /// </summary>
    Pending = 1,
    
    /// <summary>
    /// Order has been confirmed by the seller
    /// </summary>
    Confirmed = 2,
    
    /// <summary>
    /// Order is being prepared for delivery
    /// </summary>
    Processing = 3,
    
    /// <summary>
    /// Order is out for delivery
    /// </summary>
    OutForDelivery = 10,
    
    /// <summary>
    /// Order has been delivered successfully
    /// </summary>
    Delivered = 9,
    
    /// <summary>
    /// Order has been cancelled
    /// </summary>
    Cancelled = 6,
    
    /// <summary>
    /// Order has been refunded
    /// </summary>
    Refunded = 7,
} 
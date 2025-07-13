using System;

namespace MahalliyMarket.CommonUtils;

/// <summary>
/// Utility class for generating unique order numbers
/// </summary>
public static class OrderNumberGenerator
{
    /// <summary>
    /// Generates a unique order number in format "ORD-UTC time+ id"
    /// Example: "ORD-20241201143022-001"
    /// </summary>
    /// <param name="orderId">The order ID to include in the number</param>
    /// <returns>Unique order number string</returns>
    public static string GenerateOrderNumber(int orderId)
    {
        // Get current UTC time
        var utcNow = DateTime.UtcNow;
        
        // Format: ORD-YYYYMMDDHHMMSS-XXX
        var timeStamp = utcNow.ToString("yyyyMMddHHmmss");
        var orderIdPadded = orderId.ToString("D3"); // Pad with leading zeros to 3 digits
        
        return $"ORD-{timeStamp}-{orderIdPadded}";
    }

    /// <summary>
    /// Generates a unique order number with custom timestamp
    /// </summary>
    /// <param name="orderId">The order ID to include in the number</param>
    /// <param name="timestamp">Custom timestamp to use</param>
    /// <returns>Unique order number string</returns>
    public static string GenerateOrderNumber(int orderId, DateTime timestamp)
    {
        // Format: ORD-YYYYMMDDHHMMSS-XXX
        var timeStamp = timestamp.ToString("yyyyMMddHHmmss");
        var orderIdPadded = orderId.ToString("D3"); // Pad with leading zeros to 3 digits
        
        return $"ORD-{timeStamp}-{orderIdPadded}";
    }

    /// <summary>
    /// Validates if a string is a valid order number format
    /// </summary>
    /// <param name="orderNumber">Order number to validate</param>
    /// <returns>True if valid format, false otherwise</returns>
    public static bool IsValidOrderNumber(string orderNumber)
    {
        if (string.IsNullOrWhiteSpace(orderNumber))
            return false;

        // Check if it matches the pattern: ORD-YYYYMMDDHHMMSS-XXX
        var pattern = @"^ORD-\d{14}-\d{3}$";
        return System.Text.RegularExpressions.Regex.IsMatch(orderNumber, pattern);
    }

    /// <summary>
    /// Extracts the order ID from an order number
    /// </summary>
    /// <param name="orderNumber">Order number to parse</param>
    /// <returns>Order ID if valid, null otherwise</returns>
    public static int? ExtractOrderId(string orderNumber)
    {
        if (!IsValidOrderNumber(orderNumber))
            return null;

        try
        {
            var parts = orderNumber.Split('-');
            if (parts.Length == 3 && int.TryParse(parts[2], out int orderId))
            {
                return orderId;
            }
        }
        catch
        {
            // Return null if parsing fails
        }

        return null;
    }

    /// <summary>
    /// Extracts the timestamp from an order number
    /// </summary>
    /// <param name="orderNumber">Order number to parse</param>
    /// <returns>DateTime if valid, null otherwise</returns>
    public static DateTime? ExtractTimestamp(string orderNumber)
    {
        if (!IsValidOrderNumber(orderNumber))
            return null;

        try
        {
            var parts = orderNumber.Split('-');
            if (parts.Length == 3 && DateTime.TryParseExact(parts[1], "yyyyMMddHHmmss", null, System.Globalization.DateTimeStyles.None, out DateTime timestamp))
            {
                return timestamp;
            }
        }
        catch
        {
            // Return null if parsing fails
        }

        return null;
    }
} 
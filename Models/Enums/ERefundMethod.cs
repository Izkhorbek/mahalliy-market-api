namespace MahalliyMarket.Models;

/// <summary>
/// Enumeration for refund methods
/// </summary>
public enum ERefundMethod
{
    /// <summary>
    /// Cash refund
    /// </summary>
    Cash = 1,
    
    /// <summary>
    /// Credit card refund
    /// </summary>
    CreditCard = 2,
    
    /// <summary>
    /// Debit card refund
    /// </summary>
    DebitCard = 3,
    
    /// <summary>
    /// Bank transfer
    /// </summary>
    BankTransfer = 4,
    
    /// <summary>
    /// Other refund methods
    /// </summary>
    Other = 5
}

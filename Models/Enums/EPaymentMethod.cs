namespace MahalliyMarket.Models;

/// <summary>
/// Enumeration for payment methods
/// </summary>
public enum EPaymentMethod
{
    /// <summary>
    /// Cash payment
    /// </summary>
    Cash = 1,
    
    /// <summary>
    /// Credit card payment
    /// </summary>
    CreditCard = 2,
    
    /// <summary>
    /// Debit card payment
    /// </summary>
    DebitCard = 3,
    
    /// <summary>
    /// Bank transfer
    /// </summary>
    BankTransfer = 4,
    
    /// <summary>
    /// Other payment methods
    /// </summary>
    Other = 5
} 
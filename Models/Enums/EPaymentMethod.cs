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
    
    // /// <summary>
    // /// Mobile money payment
    // /// </summary>
    // MobileMoney = 5,
    
    // /// <summary>
    // /// Digital wallet payment
    // /// </summary>
    // DigitalWallet = 6,
    
    // /// <summary>
    // /// PayPal payment
    // /// </summary>
    // PayPal = 7,
    
    // /// <summary>
    // /// Cryptocurrency payment
    // /// </summary>
    // Cryptocurrency = 8,
    
    // /// <summary>
    // /// Check payment
    // /// </summary>
    // Check = 9,
    
    // /// <summary>
    // /// Money order
    // /// </summary>
    // MoneyOrder = 10,
    
    // /// <summary>
    // /// Installment payment
    // /// </summary>
    // Installment = 11,
    
    /// <summary>
    /// Other payment methods
    /// </summary>
    Other = 12
} 
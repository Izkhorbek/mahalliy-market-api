using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MahalliyMarket.Models;

public class Cart
{
    /// <summary>
    /// Unique identifier for the shopping cart
    /// </summary>
    [Key]
    public int cart_id { get; set; }
    
    /// <summary>
    /// ID of the customer who owns this cart
    /// </summary>
    [Required(ErrorMessage = "Customer ID is required for cart")]
    public int customer_id { get; set; }
    
    /// <summary>
    /// Navigation property to the customer
    /// </summary>
    [ForeignKey("customer_id")]
    public virtual User? customer { get; set; }
    
    /// <summary>
    /// Type of cart (Shopping Cart, Wishlist)
    /// </summary>
    public ECartType cart_type { get; set; } = ECartType.Shopping;
    
    /// <summary>
    /// Total number of items in the cart
    /// </summary>
    public int total_items { get; set; } = 0;
    
    /// <summary>
    /// Total quantity of all items in the cart
    /// </summary>
    public int total_quantity { get; set; } = 0;
    
    /// <summary>
    /// Subtotal amount before discounts and taxes
    /// </summary>
    [Range(0, 1000000.00, ErrorMessage = "Subtotal must be between $0.00 and $1,000,000.00")]
    [Column(TypeName = "decimal(18,2)")]
    public decimal subtotal { get; set; } = 0;
    
    /// <summary>
    /// Total discount amount applied to the cart
    /// </summary>
    [Range(0, 1000000.00, ErrorMessage = "Total discount must be between $0.00 and $1,000,000.00")]
    [Column(TypeName = "decimal(18,2)")]
    public decimal total_discount { get; set; } = 0;
    
    /// <summary>
    /// Tax amount for the cart
    /// </summary>
    [Range(0, 1000000.00, ErrorMessage = "Tax amount must be between $0.00 and $1,000,000.00")]
    [Column(TypeName = "decimal(18,2)")]
    public decimal tax_amount { get; set; } = 0;
    
    /// <summary>
    /// Shipping cost for the cart
    /// </summary>
    [Range(0, 1000000.00, ErrorMessage = "Shipping cost must be between $0.00 and $1,000,000.00")]
    [Column(TypeName = "decimal(18,2)")]
    public decimal shipping_cost { get; set; } = 0;
    
    /// <summary>
    /// Final total amount including all charges
    /// </summary>
    [Range(0, 1000000.00, ErrorMessage = "Total amount must be between $0.00 and $1,000,000.00")]
    [Column(TypeName = "decimal(18,2)")]
    public decimal total_amount { get; set; } = 0;
    
    /// <summary>
    /// Currency of the cart amounts
    /// </summary>
    [Required(ErrorMessage = "Currency is required")]
    [StringLength(3, MinimumLength = 3, ErrorMessage = "Currency must be exactly 3 characters")]
    public string currency { get; set; } = "UZS";
    
    /// <summary>
    /// Indicates if the cart is active and valid
    /// </summary>
    public bool is_active { get; set; } = true;
        
    /// <summary>
    /// Indicates if the cart has been abandoned
    /// </summary>
    public bool is_purchased { get; set; } = false;
    
//     /// <summary>
//     /// Timestamp when cart was last accessed
//     /// </summary>
//     public DateTime last_accessed_at { get; set; } = DateTime.UtcNow;
    
    /// <summary>
    /// Timestamp when cart expires (for abandoned carts)
    /// </summary>
    public DateTime? purchased_at { get; set; }
    
    /// <summary>
    /// Timestamp when the cart was created
    /// </summary>
    public DateTime created_at { get; set; } = DateTime.UtcNow;
    
    /// <summary>
    /// Timestamp when the cart was last updated
    /// </summary>
    public DateTime updated_at { get; set; } = DateTime.UtcNow;
    
    /// <summary>
    /// Collection of items in this cart
    /// </summary>
    public virtual ICollection<CartItem> cart_items { get; set; } = new List<CartItem>();
}

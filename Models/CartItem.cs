using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MahalliyMarket.Models;

public class CartItem
{
    /// <summary>
    /// Unique identifier for the cart item
    /// </summary>
    [Key]
    public int cart_item_id { get; set; }
    
    /// <summary>
    /// ID of the cart this item belongs to
    /// </summary>
    [Required(ErrorMessage = "Cart ID is required for cart item")]
    public int cart_id { get; set; }
    
    /// <summary>
    /// Navigation property to the cart
    /// </summary>
    [ForeignKey("cart_id")]
    public virtual Cart? cart { get; set; }
    
    /// <summary>
    /// ID of the product in this cart item
    /// </summary>
    [Required(ErrorMessage = "Product ID is required for cart item")]
    public int product_id { get; set; }
    
    /// <summary>
    /// Navigation property to the product
    /// </summary>
    [ForeignKey("product_id")]
    public virtual Product? product { get; set; }
    
    /// <summary>
    /// ID of the seller of this product
    /// </summary>
    [Required(ErrorMessage = "Seller ID is required")]
    public int seller_id { get; set; }
    
    /// <summary>
    /// Navigation property to the seller
    /// </summary>
    [ForeignKey("seller_id")]
    public virtual User? seller { get; set; }
    
    /// <summary>
    /// Quantity of the product in cart
    /// </summary>
    [Required(ErrorMessage = "Quantity is required")]
    [Range(1, 1000, ErrorMessage = "Quantity must be between 1 and 1000")]
    public int quantity { get; set; }
    
    /// <summary>
    /// Unit price of the product at the time it was added to cart
    /// </summary>
    [Required(ErrorMessage = "Unit price is required")]
    [Range(0.01, 1000000.00, ErrorMessage = "Unit price must be between $0.01 and $1,000,000.00")]
    [Column(TypeName = "decimal(18,2)")]
    public decimal unit_price { get; set; }
    
    /// <summary>
    /// Total price for this item (quantity * unit_price)
    /// </summary>
    [Required(ErrorMessage = "Total price is required")]
    [Range(0.01, 1000000.00, ErrorMessage = "Total price must be between $0.01 and $1,000,000.00")]
    [Column(TypeName = "decimal(18,2)")]
    public decimal total_price { get; set; }
    
    /// <summary>
    /// Discount percentage applied to this item
    /// </summary>
    [Range(0, 100, ErrorMessage = "Discount percentage must be between 0% and 100%")]
    public decimal discount_percentage { get; set; } = 0;
    
    /// <summary>
    /// Discount amount for this item
    /// </summary>
    [Range(0, 1000000.00, ErrorMessage = "Discount amount must be between $0.00 and $1,000,000.00")]
    [Column(TypeName = "decimal(18,2)")]
    public decimal discount_amount { get; set; } = 0;
    
    /// <summary>
    /// Final price after discount
    /// </summary>
    [Required(ErrorMessage = "Final price is required")]
    [Range(0.01, 1000000.00, ErrorMessage = "Final price must be between $0.01 and $1,000,000.00")]
    [Column(TypeName = "decimal(18,2)")]
    public decimal final_price { get; set; }
    
//     /// <summary>
//     /// Indicates if this item is available for purchase
//     /// </summary>
//     public bool is_available { get; set; } = true;
    
//     /// <summary>
//     /// Indicates if this item is selected for checkout
//     /// </summary>
//     public bool is_selected { get; set; } = true;
    
    /// <summary>
    /// Estimated delivery date for this item
    /// </summary>
    public DateTime? estimated_delivery_date { get; set; }
    
    /// <summary>
    /// Timestamp when this item was added to cart
    /// </summary>
    public DateTime added_at { get; set; } = DateTime.UtcNow;
    
    /// <summary>
    /// Timestamp when this item was last updated
    /// </summary>
    public DateTime updated_at { get; set; } = DateTime.UtcNow;
    
    /// <summary>
    /// Timestamp when this item expires (for perishable items)
    /// </summary>
    public DateTime? expires_at { get; set; }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MahalliyMarket.Models;

public class ProductSwiper
{
    /// <summary>
    /// Unique identifier for the product swiper entry
    /// </summary>
    [Key]
    public int swiper_id { get; set; }

    /// <summary>
    /// ID of the product to be displayed in swiper
    /// </summary>
    [Required(ErrorMessage = "Product ID is required for swiper")]
    public int product_id { get; set; }

    /// <summary>
    /// Navigation property to the product
    /// </summary>
    [ForeignKey("product_id")]
    public Product? product { get; set; }

    /// <summary>
    /// ID of the seller/business
    /// </summary>
    [Required(ErrorMessage = "Seller ID is required")]
    public int seller_id { get; set; }

    /// <summary>
    /// Navigation property to the seller
    /// </summary>
    [ForeignKey("seller_id")]
    public User? seller { get; set; }

    /// <summary>
    /// Title/headline for the swiper item
    /// </summary>
    [Required(ErrorMessage = "Swiper title is required")]
    [StringLength(200, ErrorMessage = "Swiper title cannot exceed 200 characters")]
    public string title { get; set; } = string.Empty;

    /// <summary>
    /// Subtitle or tagline for the swiper item
    /// </summary>
    [StringLength(300, ErrorMessage = "Subtitle cannot exceed 300 characters")]
    public string? subtitle { get; set; }

    /// <summary>
    /// Description for the swiper item
    /// </summary>
    [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters")]
    public string? description { get; set; }

    /// <summary>
    /// Type of swiper (Featured, New Arrivals, Best Sellers, etc.)
    /// </summary>
    [Required(ErrorMessage = "Swiper type is required")]
    [StringLength(50, ErrorMessage = "Swiper type cannot exceed 50 characters")]
    public string swiper_type { get; set; } = string.Empty;

    /// <summary>
    /// Category of the swiper (Homepage, Category Page, etc.)
    /// </summary>
    [Required(ErrorMessage = "Swiper category is required")]
    [StringLength(50, ErrorMessage = "Swiper category cannot exceed 50 characters")]
    public string swiper_category { get; set; } = string.Empty;

    /// <summary>
    /// Image URL for the swiper item
    /// </summary>
    [Required(ErrorMessage = "Swiper image URL is required")]
    [StringLength(500, ErrorMessage = "Image URL cannot exceed 500 characters")]
    public string image_url { get; set; } = string.Empty;

    //     /// <summary>
    //     /// Background image URL for the swiper item
    //     /// </summary>
    //     [StringLength(500, ErrorMessage = "Background image URL cannot exceed 500 characters")]
    //     public string? background_image_url { get; set; }

    /// <summary>
    /// Order in which items should appear in the swiper
    /// </summary>
    public int display_order { get; set; } = 1;

    //     /// <summary>
    //     /// Priority level for display (higher number = higher priority)
    //     /// </summary>
    //     public int priority { get; set; } = 1;

    /// <summary>
    /// Indicates if this item is active and visible
    /// </summary>
    public bool is_active { get; set; } = true;

    //     /// <summary>
    //     /// Call-to-action text (e.g., "Shop Now", "Learn More")
    //     /// </summary>
    //     [StringLength(50, ErrorMessage = "CTA text cannot exceed 50 characters")]
    //     public string? cta_text { get; set; }

    //     /// <summary>
    //     /// Call-to-action URL
    //     /// </summary>
    //     [StringLength(500, ErrorMessage = "CTA URL cannot exceed 500 characters")]
    //     public string? cta_url { get; set; }

    //     /// <summary>
    //     /// Badge text (e.g., "New", "Sale", "Limited Time")
    //     /// </summary>
    //     [StringLength(30, ErrorMessage = "Badge text cannot exceed 30 characters")]
    //     public string? badge_text { get; set; }

    //     /// <summary>
    //     /// Badge color (e.g., "red", "green", "blue")
    //     /// </summary>
    //     [StringLength(20, ErrorMessage = "Badge color cannot exceed 20 characters")]
    //     public string? badge_color { get; set; }

    //     /// <summary>
    //     /// Discount percentage to display
    //     /// </summary>
    //     [Range(0, 100, ErrorMessage = "Discount percentage must be between 0% and 100%")]
    //     public decimal? discount_percentage { get; set; }

    //     /// <summary>
    //     /// Original price to display
    //     /// </summary>
    //     [Range(0, 1000000.00, ErrorMessage = "Original price must be between $0.00 and $1,000,000.00")]
    //     [Column(TypeName = "decimal(18,2)")]
    //     public decimal? original_price { get; set; }

    //     /// <summary>
    //     /// Sale price to display
    //     /// </summary>
    //     [Range(0, 1000000.00, ErrorMessage = "Sale price must be between $0.00 and $1,000,000.00")]
    //     [Column(TypeName = "decimal(18,2)")]
    //     public decimal? sale_price { get; set; }

    //     /// <summary>
    //     /// Currency for prices
    //     /// </summary>
    //     [StringLength(3, MinimumLength = 3, ErrorMessage = "Currency must be exactly 3 characters")]
    //     public string currency { get; set; } = "UZS";

    /// <summary>
    /// Start date when this item should be shown
    /// </summary>
    public DateTime? start_date { get; set; }

    /// <summary>
    /// End date when this item should stop being shown
    /// </summary>
    public DateTime? end_date { get; set; }

    /// <summary>
    /// Number of times this item has been viewed
    /// </summary>
    public int view_count { get; set; } = 0;

    /// <summary>
    /// Number of times this item has been clicked
    /// </summary>
    public int click_count { get; set; } = 0;

    //     /// <summary>
    //     /// Conversion rate (clicks/views)
    //     /// </summary>
    //     [Range(0, 1, ErrorMessage = "Conversion rate must be between 0 and 1")]
    //     public decimal conversion_rate { get; set; } = 0;

    //     /// <summary>
    //     /// Additional CSS classes for styling
    //     /// </summary>
    //     [StringLength(200, ErrorMessage = "CSS classes cannot exceed 200 characters")]
    //     public string? css_classes { get; set; }

    //     /// <summary>
    //     /// Custom styling (JSON format)
    //     /// </summary>
    //     [StringLength(1000, ErrorMessage = "Custom styling cannot exceed 1000 characters")]
    //     public string? custom_styling { get; set; }

    /// <summary>
    /// SEO title for the swiper item
    /// </summary>
    [StringLength(200, ErrorMessage = "SEO title cannot exceed 200 characters")]
    public string? seo_title { get; set; }

    /// <summary>
    /// SEO description for the swiper item
    /// </summary>
    [StringLength(500, ErrorMessage = "SEO description cannot exceed 500 characters")]
    public string? seo_description { get; set; }

    /// <summary>
    /// Alt text for the image
    /// </summary>
    [StringLength(200, ErrorMessage = "Alt text cannot exceed 200 characters")]
    public string? alt_text { get; set; }

    /// <summary>
    /// Timestamp when the swiper item was created
    /// </summary>
    public DateTime created_at { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Timestamp when the swiper item was last updated
    /// </summary>
    public DateTime updated_at { get; set; } = DateTime.UtcNow;
}
